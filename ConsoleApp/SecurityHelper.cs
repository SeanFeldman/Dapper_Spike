using System;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp
{
    class SecurityHelper
    {
        public string GetHashedPassword(string plainPassword, string salt)
        {
            var sha1 = new MD5CryptoServiceProvider();
            var passwordBytes = Encoding.ASCII.GetBytes(plainPassword);
            var saltBytes = Encoding.ASCII.GetBytes(salt);
            var allBytes = new Byte[passwordBytes.Length + salt.Length];

            Array.Copy(passwordBytes, allBytes, passwordBytes.Length);
            Array.Copy(saltBytes, 0, allBytes, passwordBytes.Length, saltBytes.Length);

            var hash = sha1.ComputeHash(passwordBytes);
            return Convert.ToBase64String(hash);
        }
    }
}
