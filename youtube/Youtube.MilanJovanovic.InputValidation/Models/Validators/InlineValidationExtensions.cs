using FluentValidation;
using FluentValidation.Results;

namespace Youtube.MilanJovanovic.InputValidation.Models.Validators;

internal static class InlineValidationExtensions 
{
    public static async Task<ValidationResult> ValidateInlineAsync<T>(this T obj, Action<InlineValidator<T>> configure) 
    {
        var validator = new InlineValidator<T>();
        configure(validator);

        return await validator.ValidateAsync(obj);
    }
}