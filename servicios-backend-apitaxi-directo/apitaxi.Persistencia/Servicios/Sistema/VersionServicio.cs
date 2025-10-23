using System.Reflection;

namespace ApiTaxi.Persistencia.Servicios.Sistema
{
    public class VersionServicio : IVersionServicio
    {
        public string ObtenerVersion()
        {
            var assembly = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
            var version = assembly.GetName().Version;
            var name = assembly.GetName().Name;

            return $"Product Name: {name}, Version: {version?.Major}.{version?.Minor}.{version?.Build}.{version?.Revision}";
        }
    }
}
