using Youtube.MilanJovanovic.InputValidation;

// Configure Services
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerConfiguration();

// Configure the HTTP request pipeline.
var app = builder.Build();

app.UseSwaggerConfiguration(app.Environment);
app.UseApiConfiguration();

// Configure routes endpoints
app.RegisterWeatherForecastEndpoints();

app.Run();
