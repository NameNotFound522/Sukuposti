namespace Sukuposti.Application.Services.Interfaces;

public interface IJwtService
{
    public string GenerateJwt(int userId, string email, List<string> roles);
}