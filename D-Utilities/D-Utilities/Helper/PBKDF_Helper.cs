using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace D_Utilities
{
    /// <summary>
    /// Uses password-based key derivation kuction standards to hash user passwords.
    /// </summary>
    public class PBKDF_Helper
    {
        /// <summary>
        /// Generates a 512 bit salt.
        /// </summary>
        /// <returns></returns>
        public static byte[] GenerateSalt()
        {
            var RNG = new byte[64];

            new Random().NextBytes(RNG);

            return RNG;
        }

        /// <summary>
        /// Generates a 256 bit encrypted hashed password.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <param name="NumberOfRounds"></param>
        /// <returns></returns>
        public static string HashPassword(string password, byte[] salt, int NumberOfRounds)
        {
            byte[] toBeHashed = Encoding.UTF8.GetBytes(password);

            using (var rfc2898 = new Rfc2898DeriveBytes(toBeHashed, salt, NumberOfRounds))
            {
                return Convert.ToBase64String(rfc2898.GetBytes(32));
            }
        }
    }
}
