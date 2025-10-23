using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace ApiTaxi.Persistencia.Servicios.Red
{
    public class NetworkHelper : INetworkHelper
    {
        public string GetFQDN()
        {
            try
            {
                string hostName = Dns.GetHostName();
                string domainName = IPGlobalProperties.GetIPGlobalProperties().DomainName;

                if (string.IsNullOrWhiteSpace(domainName))
                    return hostName;

                if (!hostName.EndsWith(domainName, StringComparison.OrdinalIgnoreCase))
                    return $"{hostName}.{domainName}";

                return hostName;
            }
            catch
            {
                // Si ocurre algún error, al menos retorna el nombre del host
                return Environment.MachineName;
            }
        }

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
