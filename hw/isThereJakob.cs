using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10
{
    class Program
    {
        static void CountM(string[] names)
        {
            int total = 0;
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i][0] == 'm' || names[i][0] == 'M')
                {
                    total++;
                }
            }
            Console.WriteLine($"There are {total} names that start with M.");
        }

        static bool IsJakob(string[] names)
        {
            int i = 0;
            while (i < names.Length && names[i].ToLower() != "jabob")
            {
                i++;
            }
            return i <= names.Length;
        }

        static void Main(string[] args)
        {
            Console.Write("How many names will be? ");
            int n = Convert.ToInt32(Console.ReadLine());
            string[] names = new string[n];
            int i = 0;
            while (i < names.Length)
            {
                Console.Write($"Enter {i + 1}. name: ");
                names[i] = Console.ReadLine();
                i++;
            }
            Console.WriteLine(IsJakob(names));

            string[] before = new string[n];
            string[] after = new string[n];
            int bindex = 0;
            int aindex = 0;
            bool H = false;

            for (int a = 0; a < names.Length; a++)
            {
                if (names[a][0] == 'h' || names[a][0] == 'H')
                {
                    H = true;
                }
                if (!H)
                {
                    before[bindex] = names[a];
                    bindex++;
                }
                else
                {
                    after[aindex] = names[a];
                    aindex++;
                }

            }
            if (H)
            {
                Console.WriteLine("Before H:");
                for (int b = 0; b < before.Length; b++)
                {
                    Console.WriteLine(before[b]);
                }
                Console.WriteLine("After H:");
                for (int a = 1; a < after.Length; a++) // exclude H
                {
                    Console.WriteLine(after[a]);
                }
            }
            
            Console.WriteLine("--------");
            Console.ReadKey();
        }
    }
}
