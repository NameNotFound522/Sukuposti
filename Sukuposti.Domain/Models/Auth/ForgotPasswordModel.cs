using System.ComponentModel.DataAnnotations;

namespace Sukuposti.Domain.Models;

public class ForgotPasswordModel
{
    [EmailAddress]
    public required string Email { get; set; }
}