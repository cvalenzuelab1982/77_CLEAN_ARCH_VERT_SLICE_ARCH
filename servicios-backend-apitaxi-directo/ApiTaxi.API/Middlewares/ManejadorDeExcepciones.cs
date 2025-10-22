using ApiTaxi.Aplicacion.Execpciones;
using System.Net;
using System.Text.Json;

namespace ApiTaxi.API.Middlewares
{
    public class ManejadorDeExcepciones
    {
        private readonly RequestDelegate _next;

        public ManejadorDeExcepciones(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ManejarExcepcion(context, ex);
            }
        }

        private Task ManejarExcepcion(HttpContext context, Exception exception)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var resultado = string.Empty;

            switch (exception)
            {
                case ExcepcionNoEncontrado:
                    httpStatusCode = HttpStatusCode.NotFound;
                    break;
                case ExepcionDeValidacion exepcionDeValidacion:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    resultado = JsonSerializer.Serialize(exepcionDeValidacion.ErroresDeValidacion);
                    break;
            }

            context.Response.StatusCode = (int)httpStatusCode;
            return context.Response.WriteAsync(resultado);
        }
    }

    public static class ManejadorExcepcionesExtension
    {
        public static IApplicationBuilder UseManejadorExcepciones(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ManejadorDeExcepciones>();
        }
    }
}
