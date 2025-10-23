using ApiTaxi.Persistencia.Servicios.Seguridad;
using System.Security.Cryptography;
using System.Text;

namespace ApiTaxi.Persistence.Servicios.Seguridad
{
    public class Encripta : IEncripta
    {
        private const string iFrasePasswd = "15646^&amp;%$3(),>2134bgGz*-+e7hds";

        public string Encriptar(string cadena)
        {
            byte[] resultados;
            UTF8Encoding utf8 = new UTF8Encoding();
            MD5CryptoServiceProvider provHash = new MD5CryptoServiceProvider();
            byte[] llaveTDES = provHash.ComputeHash(utf8.GetBytes(iFrasePasswd));

            TripleDESCryptoServiceProvider algTDES = new TripleDESCryptoServiceProvider()
            {
                Key = llaveTDES,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            byte[] datoEncriptar = utf8.GetBytes(cadena);
            try
            {
                ICryptoTransform encriptador = algTDES.CreateEncryptor();
                resultados = encriptador.TransformFinalBlock(datoEncriptar, 0, datoEncriptar.Length);
            }
            finally
            {
                algTDES.Clear();
                provHash.Clear();
            }

            return Convert.ToBase64String(resultados);
        }

        public string Desencriptar(string cadena)
        {
            byte[] resultados;
            UTF8Encoding utf8 = new UTF8Encoding();
            MD5CryptoServiceProvider provHash = new MD5CryptoServiceProvider();
            byte[] llaveTDES = provHash.ComputeHash(utf8.GetBytes(iFrasePasswd));

            TripleDESCryptoServiceProvider algTDES = new TripleDESCryptoServiceProvider()
            {
                Key = llaveTDES,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            byte[] datoADesencriptar = Convert.FromBase64String(cadena);
            try
            {
                ICryptoTransform desencr = algTDES.CreateDecryptor();
                resultados = desencr.TransformFinalBlock(datoADesencriptar, 0, datoADesencriptar.Length);
            }
            finally
            {
                algTDES.Clear();
                provHash.Clear();
            }

            return utf8.GetString(resultados);
        }
    }
}
