using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MachineKeyGenerator
{
    class App
    {
        static void Main(string[] argv)
        {
            int len = 128;
            var byteSize = Console.ReadLine();
            if (byteSize.Length > 0)
                len = int.Parse(byteSize);
            byte[] buff = new byte[len / 2];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buff);
            StringBuilder sb = new StringBuilder(len);
            for (int i = 0; i < buff.Length; i++)
                sb.Append(string.Format("{0:X2}", buff[i]));
            var output = sb.ToString();
            Console.WriteLine(output);
            
        }
    }
}

