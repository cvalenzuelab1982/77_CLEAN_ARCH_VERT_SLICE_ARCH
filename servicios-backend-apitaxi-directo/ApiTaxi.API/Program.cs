using ApiTaxi.API.Middlewares;
using ApiTaxi.Aplicacion;
using ApiTaxi.Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AgregarServicioDeAplicacion();
builder.Services.AgregarServicioDePersistencia();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseManejadorExcepciones();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
