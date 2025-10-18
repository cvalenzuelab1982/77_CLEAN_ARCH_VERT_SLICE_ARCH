using Catalogo.Api.Extensions;
using Catalogo.Application;
using Catalogo.Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Catalogo de productos",
        Version = "v1"
    });
});
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ApplyMigration();

//app.UseHttpsRedirection();

await app.SeedCatalogoProduct();

app.UseAuthorization();

app.MapControllers();

//Para que se pueda manejar archivos dentro una carpeta del servidor
app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();
