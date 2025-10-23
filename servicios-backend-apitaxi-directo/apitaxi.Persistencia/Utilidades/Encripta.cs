using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Common.Security
{
    public static class Encripta
    {
        // ⚠️ No cambies esta frase si ya tienes datos cifrados en la base de datos
        private const string iFrasePasswd = "15646^&%$3(),>2134bgGz*-+e7hds";

        public static string EncriptarTripleDES(string cadena)
        {
            if (string.IsNullOrEmpty(cadena))
                return cadena;

            byte[] resultados;
            UTF8Encoding utf8 = new UTF8Encoding();

            using var provHash = MD5.Create();
            byte[] llaveTDES = provHash.ComputeHash(utf8.GetBytes(iFrasePasswd));

            using var algTDES = new TripleDESCryptoServiceProvider
            {
                Key = llaveTDES,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            byte[] datoEncriptar = utf8.GetBytes(cadena);

            using ICryptoTransform encriptador = algTDES.CreateEncryptor();
            resultados = encriptador.TransformFinalBlock(datoEncriptar, 0, datoEncriptar.Length);

            return Convert.ToBase64String(resultados);
        }

        public static string DesencriptarTripleDES(string cadena)
        {
            if (string.IsNullOrEmpty(cadena))
                return cadena;

            byte[] resultados;
            UTF8Encoding utf8 = new UTF8Encoding();

            using var provHash = MD5.Create();
            byte[] llaveTDES = provHash.ComputeHash(utf8.GetBytes(iFrasePasswd));

            using var algTDES = new TripleDESCryptoServiceProvider
            {
                Key = llaveTDES,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            byte[] datoADesencriptar = Convert.FromBase64String(cadena);

            using ICryptoTransform desencriptador = algTDES.CreateDecryptor();
            resultados = desencriptador.TransformFinalBlock(datoADesencriptar, 0, datoADesencriptar.Length);

            return utf8.GetString(resultados);
        }
    }
}
