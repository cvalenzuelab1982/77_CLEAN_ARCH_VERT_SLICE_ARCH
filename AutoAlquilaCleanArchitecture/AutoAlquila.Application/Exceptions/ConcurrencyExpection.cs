namespace AutoAlquila.Application.Exceptions
{
    public sealed class ConcurrencyExpection : Exception
    {
        //PERMITE BLOQUEAR CONCURRENCIAS QUE EN ESE MOMENTO APUNTAN A UN MISMO REGISTRO EVITA CONFLICTO, ESPERA HASTA QUE UNA OPERACION TERMINE.
        public ConcurrencyExpection(string message, Exception innerException):base(message, innerException)
        {
            
        }
    }
}
