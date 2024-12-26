using FluentValidation;
using Microsoft.Extensions.Options;

namespace Youtube.MilanJovanovic.InputValidation.Models.Validators;

internal sealed class UserRegistrationDtoValidator : AbstractValidator<UserRegistrationDto> 
{
    //private const int _minimumAge = 18;
    private int _minimumAge = 18;

    public UserRegistrationDtoValidator(IOptions<ValidationSettings> options)
    {
        _minimumAge = options.Value.MinimumAge;

        // Email validation
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");

        // Password validation
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long");

        // Password confirmation validation
        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password).WithMessage("Password do not match");
        
        // Personal info validation
        RuleFor(x => x.PersonalInfo)
            .NotNull().WithMessage("Personal information is required")
            .SetValidator(new PersonalInfoValidator());

        // Address info validation
        RuleFor(x => x.AddressInfo)
            .NotNull().WithMessage("Address information is required")
            .SetValidator(new AddressInfoValidator());

        // Código abaixo faz o mesmo que o acima (é o que uso no trabalho **')
        // When(x => x.AddressInfo is not null, () => 
        // {
        //     RuleFor(x => x.AddressInfo)
        //         .NotNull().WithMessage("Address information is required");
        // });

        RuleFor(x => x.DateOfBirth)
            .NotNull().WithMessage("{PropertyName} is required").WithName("Date birth")
            .Must(BeInPast).WithMessage("Date of birth cannot be in the future")
            .Must(x => BeValidAge(x, _minimumAge)).WithMessage($"You must be at least {_minimumAge} years old to register");

        RuleFor(x => x.AcceptTerms)
            .Equal(true).WithMessage("You must accept the terms and conditions");
    }

    // PARE EM 12:47 min do vídeo
    private static bool BeInPast(DateTime dateOfBirth) => dateOfBirth < DateTime.Today;

    private static bool BeValidAge (DateTime dateOfBirth, int minimumAge)
    {
        var age = DateTime. Today. Year- dateOfBirth. Year;

        if (DateTime.Today. AddYears (-age) < dateOfBirth)
            age--;

        return age >= minimumAge;
    }
}

internal sealed class PersonalInfoValidator : AbstractValidator<PersonalInfo> 
{
    public PersonalInfoValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required");
    }
}

internal sealed class AddressInfoValidator : AbstractValidator<AddressInfo> 
{
    public AddressInfoValidator()
    {
        RuleFor(x => x.Street)
            .NotEmpty().WithMessage("Street is required");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required");

        RuleFor(x => x.PostalCode)
            .NotEmpty().WithMessage("Postal code is required");

        RuleFor(x => x.State)
            .NotEmpty().WithMessage("State is required");

        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Country is required");

        //RuleFor(x => x).MustAsync((a, _) => addressApi.ValidateAsync(a));
    }
}

// Posso usar elementos e recursos externos, como o serviço da API abaixo para realizar as validações.
// Porém como é dito no vídeo não seria muito o ideal usar o fluent validation com dependências e sim
// somente para validações simples e superficiais que não depende de nada externo.
public interface IAddressApi 
{
    Task<bool> ValidateAsync(AddressInfo address);
}