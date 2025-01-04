using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Youtube.MilanJovanovic.InputValidation.Middlewares;

/// <summary>
/// Só funciona para MVC Controllers
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <param name="validator"></param>
[AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
public class RequestValidationAttributeFilter<TRequest>(IValidator<TRequest> validator) 
    : Attribute, IAsyncActionFilter where TRequest : class
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ActionArguments.TryGetValue(typeof(TRequest).Name.ToLower(), out var value)) 
        {
            await next();
            return;
        }

        if (value is not TRequest model)
        {
            await next();
            return;
        }
        
        ValidationResult result = await validator.ValidateAsync(model);

        if (result.IsValid) 
        {
            await next();
            return;
        }

        // Return a Problem Details with validation errors if invalid
        context.Result = new BadRequestObjectResult(new ValidationProblemDetails(result.ToDictionary())
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "Validation Failed",
            Detail = "One or more validation errors occurred.",
            Instance = context.HttpContext.Request.Path
        });
    }
}
