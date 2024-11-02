using System.Security.Cryptography;
using System.Text;

namespace TennisReservation.Helpers
{
    public class PasswordHelper
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;

        public static string HashPassword(string password)
        {
            using var rng = new RNGCryptoServiceProvider();
            var saltBytes=new byte[SaltSize];
            rng.GetBytes(saltBytes);

            using var hmac = new HMACSHA256(saltBytes);
            var hashBytes=hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            var hashWithSaltBytes=new byte[HashSize+SaltSize];
            Array.Copy(saltBytes, 0, hashWithSaltBytes, 0, SaltSize);
            Array.Copy(hashBytes, 0, hashWithSaltBytes, SaltSize, HashSize);
            
            return Convert.ToBase64String(hashWithSaltBytes);
        }

        public static bool VerifyPassword(string password,string storedHash)
        {
            var hashWithSaltBytes=Convert.FromBase64String(storedHash);

            var saltBytes = new byte[SaltSize];
            Array.Copy(hashWithSaltBytes,0,saltBytes, 0, SaltSize);

            using var hmac=new HMACSHA256(saltBytes);
            var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (int i = 0; i < HashSize; i++)
            {
                if (hashWithSaltBytes[i + SaltSize] != hashBytes[i])
                    return false;
            }

            return true;
        }
    }
}
