using System.Security.Cryptography;
using System.Text;
using BCrypt.Net;
namespace RestaurantePOS.Helpers
{
    public class Encryption
    {
        public static string GetSHA256(string str)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(str));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
        public static string GetBcrypt(string str)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(str);
            return hashedPassword;
        }

        public static bool IsValidPassword(string str,string hashed) {
            bool isValid = BCrypt.Net.BCrypt.Verify(str,hashed);
            return isValid;
        }

        public static byte[] DeriveKey(string secretKey)
        {
            using (var sha256 = SHA256.Create())
            {
                // Hash de la clave corta para generar una clave de 256 bits
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(secretKey));
            }
        }
    }
}
