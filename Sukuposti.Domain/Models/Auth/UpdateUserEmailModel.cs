using System.ComponentModel.DataAnnotations;
using Sukuposti.Domain.Custom_Attributes;

namespace Sukuposti.Domain.Models;

public class UpdateUserEmailModel
{
    [EmailAddress]
    public required string Email { get; set; }
    
    [Password]
    public required string Password { get; set; }
}