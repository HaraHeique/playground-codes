using System.Reflection;
using FluentValidation;
using Youtube.MilanJovanovic.InputValidation.Middlewares;
using Youtube.MilanJovanovic.InputValidation.Models;

namespace Youtube.MilanJovanovic.InputValidation;

public static class OpenApiConfig 
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services) 
    {
        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }

    public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app, IWebHostEnvironment env) 
    {
        if (env.IsDevelopment()) 
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        return app;
    }
}

public static class WebApiConfig 
{
    public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfiguration configuration) 
    {
        // Config padrão
        services.Configure<ValidationSettings>(configuration.GetSection(ValidationSettings.SectionKey));

        // Alternativas a configuração de cima
        services.AddOptions<ValidationSettings>()
            .BindConfiguration(ValidationSettings.SectionKey)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();

        return services;
    }

    public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app) 
    {
        app.UseHttpsRedirection();

        // Versão antiga e convencional de uso de middlewares exceçoes globais
        app.UseMiddleware<ConventionalExceptionHandlingMiddleware>();

        // Versão nova de uso de middlewares exceçoes globais (Nova versão a partir do .Net 8)
        app.UseExceptionHandler();

        return app;
    }

    /// <summary>
    /// Para trabalhar com filtros globais usando MinimalApis: https://github.com/dotnet/aspnetcore/issues/43237
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static WebApplication UseGlobalFilters(this WebApplication app) 
    {
        var routes = app.MapGroup(string.Empty);

        routes.AddEndpointFilter<RequestValidatorEndpointFilter<IRequest>>();

        return app;
    }
}

public static class ValidationConfig 
{
    public static IServiceCollection AddValidationConfiguration(this IServiceCollection services) 
    {   
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true);

        return services;
    }
}