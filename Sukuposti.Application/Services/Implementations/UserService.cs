using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Sukuposti.Application.Exceptions;
using Sukuposti.Application.Services.Interfaces;
using Sukuposti.Domain.Entities;
using Sukuposti.Domain.Models;
using Sukuposti.Infrastructure.Context;
using NotFoundException = SendGrid.Helpers.Errors.Model.NotFoundException;

namespace Sukuposti.Application.Services;

public class UserService(UserManager<User> userManager, IJwtService jwtService, IHttpContextAccessor contextAccessor,IEmailSender _emailSender,ISendGridLinkBuilder linkBuilder) : IUserService
{
    public async Task<AuthModel> RegisterUserAsync(SignUpModel model)
    {
        var user = new User()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            UserName = model.UserName
        };
        var result = await userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            result = await userManager.AddToRoleAsync(user, "User");
         
            if (result.Succeeded)
            {
                var roles = await userManager.GetRolesAsync(user);
                return new AuthModel()
                {
                    AccessToken = jwtService.GenerateJwt(user.Id, user.Email, roles.ToList())
                };
            }
        }
        throw new SignUpFailedException();
        
    }
    
    public async Task<AuthModel> LoginUserAsync(SignInModel model)
    {
        //var user = await context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
        //if (user is null) throw new SignInFailedException();
        
        //var isPasswordValid = await userManager.CheckPasswordAsync(user, model.Password);
       // if (!isPasswordValid) throw new SignInFailedException();
        
       // var roles = await userManager.GetRolesAsync(user);
        
        return new AuthModel()
        {
        //    AccessToken = jwtService.GenerateJwt(user.Id, user.Email!, roles.ToList())
        };

    }
    
    public async Task<IdentityResult> ConfirmEmailAsync(string token,string id)
    {
        var user = await userManager.FindByIdAsync(id);
        
        if (user is null) throw new ConfirmEmailFailedException();
        
        var result =  await userManager.ConfirmEmailAsync(user, token);

        return result;

    }

    public async Task<(string token, int Id)> GetConfirmationToken(string email)
    {
        var user = await userManager.FindByEmailAsync(email);
        
        if (user == null || !(await userManager.IsEmailConfirmedAsync(user)))  
            throw new ConfirmEmailFailedException();
        
        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

        return (token,user.Id);

    }

    public async Task<String> ForgotPasswordAsync(string email)
    {
        var user = await userManager.FindByEmailAsync(email);
        
        if (user == null || !(await userManager.IsEmailConfirmedAsync(user)))
            throw new ConfirmEmailFailedException();
        
        var token = await userManager.GeneratePasswordResetTokenAsync(user);
        
        return token;
    }

    public async Task<IdentityResult> ResetPasswordAsync(string token, string email,string password)
    {
        var user = await userManager.FindByEmailAsync(email);
        
        if (user is null) throw new ConfirmEmailFailedException();

        var result = await userManager.ResetPasswordAsync(user, token, password);

        return result;

    }
    public async Task<IdentityResult> ResetPasswordAsync(ResetPasswordModel model,string token)
    {
        var user = await userManager.FindByEmailAsync(model.Email);
        
        if (user == null || !(await userManager.IsEmailConfirmedAsync(user)))
            throw new ConfirmEmailFailedException();

        var result = await userManager.ResetPasswordAsync(user, token, model.Password);
        
        return result;
    }
    
    public async Task<IdentityResult> ChangeUserInfo(UpdateUserInfoModel model,string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        
        user.FirstName = model.FirstName;
        user.LastName = model.LastName;

        var result = await userManager.UpdateAsync(user);
        return result;
        
    }

    public async Task<User> GetUserInfoAsync(string id)
    {
        var user = await userManager.FindByIdAsync(id);
        return user;

    }

    public async Task<IdentityResult> ResetEmailAsync(UpdateUserEmailModel model)
    {
        var user = await userManager.FindByEmailAsync(model.Email);
        
        var isPasswordValid = await userManager.CheckPasswordAsync(user!, model.Password);

        if (!isPasswordValid) throw new SignInFailedException();

        user.Email = model.Email;

        var result = await userManager.UpdateAsync(user);
        return result;

    }
}

        