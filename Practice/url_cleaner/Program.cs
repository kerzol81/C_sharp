using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_urlNicer
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Url u = new Url("http://www.ádáméáí.com");

            Console.WriteLine(u.Nicer());
                                  

            Console.ReadKey();
        }
    }
}
