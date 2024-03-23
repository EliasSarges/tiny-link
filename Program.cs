var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices();

var app = builder.Build();

app.RegisterMiddlewares();

app.MapGet("/", () =>
{
    return "Hello World!";
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();
