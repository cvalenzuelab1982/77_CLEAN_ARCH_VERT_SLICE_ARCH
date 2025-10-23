using System.Reflection;

namespace ApiTaxi.Persistencia.Servicios.Sistema
{
    public class SistemaServicio : ISistemaServicio
    {
        public string ObtenerVersion()
        {
            var assembly = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
            var version = assembly.GetName().Version;
            var name = assembly.GetName().Name;

            return $"Product Name: {name}, Version: {version?.Major}.{version?.Minor}.{version?.Build}.{version?.Revision}";
        }

        public DateTime ObtenerFechaHoraLima()
        {
            // 1️⃣ Obtiene la zona horaria exacta de Lima desde el sistema
            var zonaLima = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            // ⚠️ En Linux/Mac sería: "America/Lima"

            // 2️⃣ Convierte la hora UTC actual a hora de Lima
            var horaLima = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, zonaLima);

            return horaLima;
        }
    }
}
