using System.Security.Cryptography;
using System.Text;

namespace SiteCorretor.Services.Security
{
    public class Md5Hash
    {
        public string CalculateMD5Hash(string input)
        {
            // Calcular o Hash
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // Converter byte array para string hexadecimal
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
