using Catalogo.Api.Extensions;
using Catalogo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.ApplyMigration();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
