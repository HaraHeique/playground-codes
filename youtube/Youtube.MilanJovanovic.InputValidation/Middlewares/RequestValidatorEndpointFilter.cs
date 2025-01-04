
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Youtube.MilanJovanovic.InputValidation.Models;

namespace Youtube.MilanJovanovic.InputValidation.Middlewares;

public class RequestValidatorEndpointFilter<TRequest> : IEndpointFilter where TRequest : IRequest
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var validator = context.HttpContext.RequestServices.GetRequiredService<IValidator<TRequest>>();

        if (validator is null) return await next(context);

        //var objectRequest = context.GetArgument<TValidator>(0);

        var objectRequest = context.Arguments
            .OfType<TRequest>()
            .FirstOrDefault(r => r?.GetType() == typeof(TRequest));

        if (objectRequest is null)
            return Results.Problem(new ProblemDetails 
            {
                Title = "Validation error",
                Detail = "Error while trying to perform validation request",
                Status = StatusCodes.Status500InternalServerError,
                Instance = context.HttpContext.Request.Path,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1"
            });

        var validationResult = await validator.ValidateAsync(objectRequest);

        if (!validationResult.IsValid)
            return Results.ValidationProblem(
                errors: validationResult.ToDictionary(),
                type: "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1"
            ); // TODO: Colocar mais infos aqui do ProblemDetails. Faltam informaçoes desta forma

        return await next(context);
    }
}
