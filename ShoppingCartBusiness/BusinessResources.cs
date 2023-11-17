using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartBusiness
{
    public class BusinessResources
    {

        public static String ConvertSha256(String text)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding encoding = Encoding.UTF8;
                byte[] result = hash.ComputeHash(encoding.GetBytes(text));

                foreach (byte b in result)
                {
                    stringBuilder.Append(b.ToString("x2"));
                }
            }
            return stringBuilder.ToString();
        }
    }
}
