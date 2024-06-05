using System.ComponentModel.DataAnnotations;
using Sukuposti.Domain.Custom_Attributes;

namespace Sukuposti.Domain.Models;

public class UpdateUserPasswordModel
{
    public required string OldPassword { get; set; }
    
    [Password]
    public required string NewPassword { get; set; }
    
    [Compare("NewPassword")]
    public required string ConfirmPassword { get; set; }
}