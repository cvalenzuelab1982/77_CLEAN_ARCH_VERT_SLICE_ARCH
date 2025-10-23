using System.Net.NetworkInformation;

namespace ApiTaxi.Persistencia.Servicios.Red
{
    public interface INetworkHelper
    {
        string? GetLocalIPv4(NetworkInterfaceType tipoInterfaz);
        string GetFQDN();
    }
}
