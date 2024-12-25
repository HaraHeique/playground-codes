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
    public static IServiceCollection AddApiConfiguration(this IServiceCollection services) 
    {
        return services;
    }

    public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app) 
    {
        app.UseHttpsRedirection();

        return app;
    }
}