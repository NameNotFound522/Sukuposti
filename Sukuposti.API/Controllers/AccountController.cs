using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Sukuposti.Domain.Models;

namespace Sukuposti.API.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController(IUserService userService,IEmailSender emailService,ISendGridLinkBuilder linkBuilder,IHttpContextAccessor contextAccessor) : ControllerBase
{
   [HttpPut("edit/names")]
   public async Task<IActionResult> UpdateUserInfo([FromBody] UpdateUserInfoModel model)
   {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      
      var userId = GetUserIdFromContext();
      var result = await userService.ChangeUserInfo(model,userId);
      return Ok(result);
   }

   [HttpPut("edit/password/reset")]
   public async Task<IActionResult> UpdateUserPassword([FromBody] UpdateUserPasswordModel model)
   {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      var userEmail = GetUserEmailFromContext();
      var token = await  userService.ForgotPasswordAsync(userEmail);
      var result = await userService.ResetPasswordAsync(token, userEmail, model.NewPassword);
      return Ok(result);
   }
   
   
   private string? GetUserIdFromContext()
   {
      return contextAccessor.HttpContext?.User.Claims
         .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?
         .Value;
   }

   private string? GetUserEmailFromContext()
   {
      return contextAccessor.HttpContext?.User.Claims
         .FirstOrDefault(c => c.Type == ClaimTypes.Email)?
         .Value;
   }
}