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
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(0, i);
                Console.Write(element);
                Console.SetCursorPosition(81, i);
                Console.Write(element);
            }
            for (int i = 0; i < 81; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
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
                Console.SetCursorPosition(r.Next(1, 79), r.Next(1, 19));
                Console.Write("x");
            }
        }


        static void Main(string[] args)
        {
            DisplayFence('#');
            PlaceSheeps(6);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(0,22);
            Console.Write("Shoot:\nX: ");
            byte x = Convert.ToByte(Console.ReadLine());
            Console.Write("Y: ");
            byte y = Convert.ToByte(Console.ReadLine());
            Console.SetCursorPosition(x, y);


            Console.ReadKey();
        }
    }
}
