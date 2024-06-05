using Microsoft.AspNetCore.Mvc;
using Sukuposti.Domain.Models;

namespace Sukuposti.API.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController(IUserService userService,IEmailSender emailService,ISendGridLinkBuilder linkBuilder) : ControllerBase
{
   [HttpPost("register")]
   public async Task<IActionResult> SignUp([FromBody] SignUpModel model)
   {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      
      var result = await userService.RegisterUserAsync(model);

      await SendConfirmationEmail(model.Email);
      
      return Ok(result);
   }

   [HttpPost("login")]
   public async Task<IActionResult> SignIn([FromBody] SignInModel model)
   {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      
      var res = await userService.LoginUserAsync(model); 
      return Ok(res);
      
   }

   [HttpPost("email/confirm")]
   public async Task<IActionResult> SendConfirmationEmail(string email)
   {
      
      var response = await userService.GetConfirmationToken(email);
      var confirmationLink = await linkBuilder.BuildConfirmationLink( response.Id.ToString(), response.token);
      await emailService.SendEmailAsync(email, "Confirmation email link", confirmationLink);
      
      return Ok();

   }

   [HttpGet("email/confirm")]
   public async Task<IActionResult> ConfirmEmail([FromQuery] string token, [FromQuery] string id)
   {
      
      var result = await userService.ConfirmEmailAsync(token, id);

      if (!result.Succeeded) return BadRequest();
      
      return Ok();
         
   }
   

   [HttpPost("password/forgot")]
   public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
   {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      
      var token = await userService.ForgotPasswordAsync(model.Email);
      var confirmationLink = await linkBuilder.BuildResetPasswordLink(token);
      var result =  emailService.SendEmailAsync(model.Email, "Confirmation Link", confirmationLink);
      return Ok(result);
   }
   
   [HttpPost]
   public async Task<IActionResult> ResetEmail(UpdateUserEmailModel model)
   {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      
      var result = await userService.ResetEmailAsync(model);
      
      if (!result.Succeeded)  return BadRequest();
      
      await SendConfirmationEmail(model.Email);
      return Ok();
      
   }

   [HttpPost("password/reset")]
   public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model, [FromQuery] string token)
   {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      
      var result = await userService.ResetPasswordAsync(model, token);
      
      if (!result.Succeeded) return BadRequest();
      
      return Ok();
   }
}