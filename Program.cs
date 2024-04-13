var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices();

var app = builder.Build();

app.RegisterMiddlewares();

app.RegisterLinkController();


if (!File.Exists("database.db"))
{
  MigrationRunner.RunMigrations();
}

app.Run();
