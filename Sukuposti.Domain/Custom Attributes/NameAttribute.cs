using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Sukuposti.Domain.Custom_Attributes;

public class NameAttribute(string fieldName) : ValidationAttribute
{
    public string FieldName { get; set; } = fieldName;
    public int MinimumLength { get; set; } = 2;
    public int MaximumLength { get; set; } = 50;

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not string name || string.IsNullOrWhiteSpace(name))
        {
            return new ValidationResult("Name is required.");
        }

        if (name.Length < MinimumLength || name.Length > MaximumLength)
        {
            return new ValidationResult($"Name must be between {MinimumLength} and {MaximumLength} characters.");
        }

        return ValidationResult.Success!;
    }
}