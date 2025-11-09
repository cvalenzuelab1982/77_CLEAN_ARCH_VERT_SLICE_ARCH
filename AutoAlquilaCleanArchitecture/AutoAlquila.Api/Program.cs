using AutoAlquila.Api.Extensions;
using AutoAlquila.Application;
using AutoAlquila.Infraestructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApplication();
builder.Services.AddInfraestructure(builder.Configuration);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.ApplyMigration();

app.SeedData();//Enviar datos fake de pruebas

app.UseCustomExceptionHandler();

app.MapControllers();

app.Run();

