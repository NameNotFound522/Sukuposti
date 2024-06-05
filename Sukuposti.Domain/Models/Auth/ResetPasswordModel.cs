using System.ComponentModel.DataAnnotations;
using Sukuposti.Domain.Custom_Attributes;

namespace Sukuposti.Domain.Models;

public class ResetPasswordModel
{
    [EmailAddress]
    public required string Email { get; set; }
    
    [Password]
    public required string Password { get; set; }
    
    [Compare("Password")]
    public required string ConfirmPassword { get; set; }
 
}