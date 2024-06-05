using Microsoft.AspNetCore.Identity;
using Sukuposti.Domain.Entities;
using Sukuposti.Domain.Models;

namespace Sukuposti.Application.Services.Interfaces;

public interface IUserService
{
    public Task<AuthModel> RegisterUserAsync(SignUpModel model);
    public Task<AuthModel> LoginUserAsync(SignInModel model);
    public Task<IdentityResult> ConfirmEmailAsync(string token, string id);
    public Task<string> ForgotPasswordAsync(string email);
    public Task<IdentityResult> ResetPasswordAsync(ResetPasswordModel model, string token);
    public Task<IdentityResult> ResetPasswordAsync(string token, string email, string password);
    public Task<IdentityResult> ResetEmailAsync(UpdateUserEmailModel model);
    public Task<IdentityResult> ChangeUserInfo(UpdateUserInfoModel model, string userId);
    Task<User> GetUserInfoAsync(string id);
    public Task<(string token, int Id)> GetConfirmationToken(string email);
    
}