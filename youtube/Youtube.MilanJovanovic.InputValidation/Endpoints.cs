namespace Youtube.MilanJovanovic.InputValidation;

public static class WeatherForecastEndpoints 
{
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
        .WithTags("WeatherForecast")
        .WithOpenApi();

        return endpointBuilder;
    }
}