using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;
using Sukuposti.Application.Services.Interfaces;

namespace Sukuposti.Application.Services;

public class SendGridLinkBuilder(ISendGridClient sendGridClient, ILogger<SendGridLinkBuilder> logger,IHttpContextAccessor contextAccessor)
    : IEmailSender, ISendGridLinkBuilder
{
    private readonly ILogger _logger = logger;

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        var msg = new SendGridMessage()
        {
            From = new EmailAddress("shotyuriua@gmail.com", "Sukuposti.net"),
            Subject = subject,
            PlainTextContent = message,
            HtmlContent = message
        };
        msg.AddTo(new EmailAddress(toEmail));

        var response = await sendGridClient.SendEmailAsync(msg);
        if (response.IsSuccessStatusCode)
        {
            _logger.LogInformation("Email queued successfully");
        }
        else
        {
            _logger.LogError("Failed to send email");
        }
    }

    public  Task<string> BuildResetPasswordLink(string token)
    {
        var request = contextAccessor.HttpContext.Request;
        var confirmationLink = $"{request.Scheme}://{request.Host}/Auth/ResetPassword?token={HttpUtility.UrlEncode(token)}";

        return Task.FromResult(confirmationLink);
    }

    public Task<string> BuildConfirmationLink(string id, string token)
    {
        var request = contextAccessor.HttpContext.Request;
        var confirmationLink =  $"{request.Scheme}://{request.Host}/Auth/confirm?token={HttpUtility.UrlEncode(token)}&id={HttpUtility.UrlEncode(id)}";
        return Task.FromResult(confirmationLink);

    }
}