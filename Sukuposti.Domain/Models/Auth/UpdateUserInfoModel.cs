using Sukuposti.Domain.Custom_Attributes;

namespace Sukuposti.Domain.Models;

public class UpdateUserInfoModel
{
    [Name("FirstName")]
    public required string FirstName { get; set; }
    
    [Name("LastName")]
    public required string LastName { get; set; }
    
}