using System.Reflection;
using FluentValidation;

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

        return services;
    }

    public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app) 
    {
        app.UseHttpsRedirection();

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