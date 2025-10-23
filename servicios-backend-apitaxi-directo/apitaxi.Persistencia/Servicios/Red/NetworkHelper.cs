using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace ApiTaxi.Persistencia.Servicios.Red
{
    public class NetworkHelper : INetworkHelper
    {
        public string? GetLocalIPv4(NetworkInterfaceType tipoInterfaz)
        {
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Solo interfaces activas del tipo solicitado
                if (item.NetworkInterfaceType == tipoInterfaz && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        // IPv4 solamente
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            return ip.Address.ToString();
                        }
                    }
                }
            }

            return null;
        }
    }
}
