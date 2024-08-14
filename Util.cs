using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Aula_l_01_04
{
    internal class Util
    {
        public static string geraSHA1(string senha)
        {
            SHA1 hasher = SHA1.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] array = encoding.GetBytes(senha);
            array = hasher.ComputeHash(array);
            StringBuilder strHexa = new StringBuilder();

            foreach (byte item in array)
            {
                strHexa.Append(item.ToString("x2"));
            }
            return strHexa.ToString();
        }
    }
}
