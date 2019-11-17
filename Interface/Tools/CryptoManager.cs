using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Tools
{
    internal static class CryptoManager
    {
        public static string TransformPassword(string orig)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(orig);
            SHA256Managed sHA256ManagedString = new SHA256Managed();
            byte[] hash = sHA256ManagedString.ComputeHash(bytes);
            for (int i = 0; i < 10; i++)
            {
                hash = sHA256ManagedString.ComputeHash(hash);
            }
            return Convert.ToBase64String(hash);
        }

    }
}
