namespace Sukuposti.Application.Services.Interfaces;

public interface ISendGridLinkBuilder
{
    public Task<string> BuildConfirmationLink(string id, string token);
    public Task<string> BuildResetPasswordLink(string token);
}