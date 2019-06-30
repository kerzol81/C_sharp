using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hunting {
    class Program {
        static void DisplayFence(char element)
        {
            for (int i = 0; i < 21; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(0, i);
                Console.Write(element);
                Console.SetCursorPosition(81, i);
                Console.Write(element);
            }
            for (int i = 0; i < 81; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(i, 0);
                Console.Write(element);
                Console.SetCursorPosition(i, 20);
                Console.Write(element);
            }
        }

        static void PlaceSheeps(byte n)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                Console.SetCursorPosition(r.Next(1, 71), r.Next(1, 19));
                Console.Write("'o'");
            }
        }


        static void Main(string[] args)
        {
            DisplayFence('#');
            PlaceSheeps(5);


            Console.ReadKey();
        }
    }
}
