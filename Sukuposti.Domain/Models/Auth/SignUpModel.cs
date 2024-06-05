using System.ComponentModel.DataAnnotations;
using Sukuposti.Domain.Custom_Attributes;

namespace Sukuposti.Domain.Models;

public class SignUpModel
{
    [EmailAddress]
    public required string Email { get; set; }
    
    [Name("Firstname")]
    public required string FirstName { get; set; }
    
    [Name("Lastname")]
    public required string LastName { get; set; }
    
    [Password]
    public required string Password { get; set; }
    
    public required string UserName { get; set; }
    
    
}