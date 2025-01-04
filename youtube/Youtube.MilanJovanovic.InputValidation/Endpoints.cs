using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Youtube.MilanJovanovic.InputValidation.Middlewares;
using Youtube.MilanJovanovic.InputValidation.Models;
using Youtube.MilanJovanovic.InputValidation.Models.Validators;

namespace Youtube.MilanJovanovic.InputValidation;

public static class WeatherForecastEndpoints 
{
    public const string TagName = "WeatherForecast";

    private static readonly string[] _summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    public static IEndpointRouteBuilder RegisterWeatherForecastEndpoints(this IEndpointRouteBuilder endpointBuilder) 
    {
        endpointBuilder.MapGet("/weatherforecast", () =>
        {
            var forecast =  Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    _summaries[Random.Shared.Next(_summaries.Length)]
                ))
                .ToArray();
            
            return forecast;
        })
        .WithName("GetWeatherForecast")
        .WithTags(TagName)
        .WithOpenApi();

        return endpointBuilder;
    }
}

public static class UserEndpoints 
{
    public const string TagName = "Users";

    public static IEndpointRouteBuilder RegisterUserEndpoints(this IEndpointRouteBuilder endpointBuilder) 
    {
        endpointBuilder.MapPost("api/users/register/legacy", (UserRegistrationDto request) =>
        {
            List<string> errors = [];

            // TODO: Pegar o código hard code de validação gigante mostrado no vídeo: https://www.youtube.com/watch?v=vaDDB7BpEgQ
            // É um código serial/sequencial/procedural com vários IF's e gigante

            if (errors.Any()) 
            {
                var problemsDetails = new HttpValidationProblemDetails(new Dictionary<string, string[]>
                {
                    { "ValidationErrors", errors.ToArray() }
                })
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Validation Failed",
                    Detail = "One or more validation errors occurred.",
                    Instance = "api/users/register/legacy"
                };

                return Results.Problem(problemsDetails);
            }

            return Results.Ok(request);
        })
        .WithName("RegisterUserOld")
        .WithTags(TagName)
        .WithOpenApi();

        endpointBuilder.MapPost("api/users/register", (UserRegistrationDto request, IValidator<UserRegistrationDto> validator) =>
        {
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid) 
            {
                // Há também a alternativa que herda de HttpValidationProblemDetails chamado ValidationProblemDetails: https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.validationproblemdetails?view=aspnetcore-9.0
                var problemsDetails = new HttpValidationProblemDetails(validationResult.ToDictionary())
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Validation Failed",
                    Detail = "One or more validation errors occurred.",
                    Instance = "api/users/register"
                };

                return Results.Problem(problemsDetails);
            }

            return Results.Ok(request);
        })
        .WithName("RegisterUser")
        .WithTags(TagName)
        .WithOpenApi();
        
        // Validação inline sem preceisar de criar classes que herdam de AbstractValidator<T>
        endpointBuilder.MapPost("api/users/register/bonus/inline-validation", async (UserRegistrationDto request) =>
        {
            var validationResult = await request.ValidateInlineAsync(x => 
            {
                // Email validation
                x.RuleFor(x => x.Email)
                    .NotEmpty().WithMessage("Email is required")
                    .EmailAddress().WithMessage("Invalid email format");

                // Password validation
                x.RuleFor(x => x.Password)
                    .NotEmpty().WithMessage("Password is required")
                    .MinimumLength(8).WithMessage("Password must be at least 8 characters long");

                // Password confirmation validation
                x.RuleFor(x => x.ConfirmPassword)
                    .Equal(x => x.Password).WithMessage("Password do not match");
                
                // Personal info validation
                x.RuleFor(x => x.PersonalInfo)
                    .NotNull().WithMessage("Personal information is required")
                    .SetValidator(new PersonalInfoValidator());

                // Address info validation
                x.RuleFor(x => x.AddressInfo)
                    .NotNull().WithMessage("Address information is required");

                x.When(x => x.AddressInfo is not null, () => 
                {
                    x.RuleFor(x => x.AddressInfo)
                        .SetValidator(new AddressInfoValidator());
                });

                x.RuleFor(x => x.DateOfBirth)
                    .NotNull().WithMessage("{PropertyName} is required").WithName("Date birth");
                    // .Must(BeInPast).WithMessage("Date of birth cannot be in the future")
                    // .Must(x => BeValidAge(x, _minimumAge)).WithMessage($"You must be at least {_minimumAge} years old to register");

                x.RuleFor(x => x.AcceptTerms)
                    .Equal(true).WithMessage("You must accept the terms and conditions");
            });

            if (!validationResult.IsValid) 
            {
                var problemsDetails = new HttpValidationProblemDetails(validationResult.ToDictionary())
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Validation Failed",
                    Detail = "One or more validation errors occurred.",
                    Instance = "api/users/register/bonus/inline-validation"
                };

                return Results.Problem(problemsDetails);
            }

            return Results.Ok(request);
        })
        .WithName("RegisterUserWithInlineValidation")
        .WithTags(TagName)
        .WithOpenApi();

        endpointBuilder.MapPost("api/users/register/bonus/endpoint-filter", (UserRegistrationDto request, IValidator<UserRegistrationDto> validator) =>
        {
            //var validationResult = validator.Validate(request);
            // A validação se encontra no IEndpointFilter

            return Results.Ok(request);
        })
        .WithName("RegisterUserWithEndpointFilter")
        .WithTags(TagName)
        .WithOpenApi()
        .AddEndpointFilter<RequestValidatorEndpointFilter<UserRegistrationDto>>();

        return endpointBuilder;
    }
}