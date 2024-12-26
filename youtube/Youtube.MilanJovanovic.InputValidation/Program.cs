using Youtube.MilanJovanovic.InputValidation;

// Configure Services
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration(builder.Configuration);
builder.Services.AddSwaggerConfiguration();
builder.Services.AddValidationConfiguration();

// Configure the HTTP request pipeline.
var app = builder.Build();

app.UseSwaggerConfiguration(app.Environment);
app.UseApiConfiguration();

// Configure routes endpoints
app.RegisterWeatherForecastEndpoints()
    .RegisterUserEndpoints();

app.Run();
