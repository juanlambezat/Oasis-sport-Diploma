using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Servicios
{
    public class jzat506_ServicioCifrado
    {
        private static readonly byte[] jzat506_Clave = SHA256.HashData(Encoding.UTF8.GetBytes("jzat506_ClaveAES_OasisSports"));
        private static readonly byte[] jzat506_VectorInicial = MD5.HashData(Encoding.UTF8.GetBytes("jzat506_IV_OasisSports"));

        public string jzat506_Cifrar(string texto)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = jzat506_Clave;
                aes.IV = jzat506_VectorInicial;

                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(texto ?? "");
                    cs.Write(bytes, 0, bytes.Length);
                    cs.FlushFinalBlock();
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public string jzat506_Descifrar(string textoCifrado)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = jzat506_Clave;
                aes.IV = jzat506_VectorInicial;

                byte[] bytes = Convert.FromBase64String(textoCifrado);

                using (MemoryStream ms = new MemoryStream(bytes))
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                using (StreamReader sr = new StreamReader(cs, Encoding.UTF8))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}
