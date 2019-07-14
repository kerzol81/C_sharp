using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_urlNicer
{
    class Url
    {
        private string address;

        public Url(string _address)
        {
            Address = _address;
        }

        public string Address { get => address; set => address = value; }

        public string Nicer()
        {
            // length has to be the same!
            char[] bad_chars = { 'á', 'é', 'í', 'ú', 'ű', 'ü', 'ó', 'ö', 'ő' };
            char[] goodchars = { 'a', 'e', 'i', 'u', 'u', 'u', 'o', 'o', 'o' };

            for (int i = 0; i < goodchars.Length; i++)
            {
                Address = Address.ToLower();

                if (bad_chars.Length != goodchars.Length)
                {
                    return "[-] badchar lenght and goodchar lenght has to be equal.";
                }
                else
                {
                    Address = Address.Replace(bad_chars[i], goodchars[i]);
                }
            }
            return Address;
        }
    }
}
