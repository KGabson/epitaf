using System;
using System.Text;
using System.Security.Cryptography;

namespace Shared
{
    public class Tools
    {
        public static string GetSHA1Hash(string str)
        {
            Encoder enc = System.Text.Encoding.Unicode.GetEncoder();

            byte[] unicodeText = new byte[str.Length * 2];
            enc.GetBytes(str.ToCharArray(), 0, str.Length, unicodeText, 0, true);

            SHA1 sha = new SHA1Managed();
            byte[] result = sha.ComputeHash(unicodeText);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("X2"));
            }

            return sb.ToString();
        } 
    }
}