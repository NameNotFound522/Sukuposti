using Microsoft.AspNetCore.Identity;

namespace Sukuposti.Domain.Entities;

public class User : IdentityUser<int>
{
    [PersonalData]
    public  string FirstName { get; set; }
    [PersonalData]
    public  string LastName { get; set; }
}