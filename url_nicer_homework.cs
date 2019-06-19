using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace url_nicer {
    class Program {

        static string Hyphen_Remover(string word, char[] from, char[] to) {

            if (from.Length == to.Length)
            {
                for (int i = 0; i < from.Length; i++)
                {
                    word = word.Replace(from[i], to[i]);
                }
                return word;
            }

            return "from and to character array must be the same lenght";
        }

        static void Main(string[] args) {

            char[] from = { 'á', 'é', 'ó', 'ő', 'ú', 'ű', 'í', ' ' };
            char[] to = { 'a', 'e', 'o', 'o', 'u','u', 'i', '_' };

            string url = null;

            Console.WriteLine("Enter urls, the script writes them to a file, until you type 'exit'");

            StreamWriter s = new StreamWriter(@"c://temp/url_list.txt", false, Encoding.UTF8);

            do
            {
                Console.Write("Enter url: ");
                url = Convert.ToString(Console.ReadLine());
                
                if (url.ToLower() != "exit")
                {
                    s.WriteLine(url);
                }

            } while (url.ToLower() != "exit");

            s.Close();
        }
    }
}
