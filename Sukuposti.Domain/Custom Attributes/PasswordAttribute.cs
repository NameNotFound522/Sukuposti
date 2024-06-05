using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Sukuposti.Domain.Custom_Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter | AttributeTargets.Field)]
public class PasswordAttribute : ValidationAttribute
{
    public int MinimumLength { get; set; } = 8;
    public int MaximumLength { get; set; } = 16;
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        var password = value as string;

        if (string.IsNullOrEmpty(password))
        {
            return new ValidationResult("Your password cannot be empty.");
        }

        if (password.Length < MinimumLength)
        {
            return new ValidationResult($"Your password length must be at least {MinimumLength}.");
        }

        if (password.Length > MaximumLength)
        {
            return new ValidationResult($"Your password length must not exceed {MaximumLength}.");
        }

        if (!Regex.IsMatch(password, @"[A-Z]"))
        {
            return new ValidationResult("Your password must contain at least one uppercase letter.");
        }

        if (!Regex.IsMatch(password, @"[a-z]"))
        {
            return new ValidationResult("Your password must contain at least one lowercase letter.");
        }

        if (!Regex.IsMatch(password, @"[0-9]"))
        {
            return new ValidationResult("Your password must contain at least one number.");
        }

        if (!Regex.IsMatch(password, @"[\!\?\*\.]"))
        {
            return new ValidationResult("Your password must contain at least one special character (!? *.).");
        }

        return ValidationResult.Success;
    }
}