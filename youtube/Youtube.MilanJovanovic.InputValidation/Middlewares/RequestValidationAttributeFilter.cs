using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Youtube.MilanJovanovic.InputValidation.Middlewares;

[AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
public class RequestValidationAttributeFilter<TValidator>(IValidator<TValidator> validator) 
    : Attribute, IAsyncActionFilter where TValidator : class
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ActionArguments.TryGetValue(typeof(TValidator).Name.ToLower(), out var value)) 
        {
            await next();
            return;
        }

        if (value is not TValidator model)
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

// TODO: Em minimal APIs parece que tem que usar o IEndpointFilter e nao tem como utilizar os AttributeFilters normais: https://medium.com/@malarsharmila/minimal-apis-with-filters-in-net-188afffce40a

