using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hunting {
    class Program {
        static bool shoot = false;
        static void DisplayFence(char element)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int y = 0; y < 21; y++)
            {

                Console.SetCursorPosition(0, y);
                Console.Write(element);
                Console.SetCursorPosition(81, y);
                Console.Write(element);
            }
            for (int x = 0; x < 81; x++)
            {
                Console.SetCursorPosition(x, 0);
                Console.Write(element);
                Console.SetCursorPosition(x, 20);
                Console.Write(element);
            }
        }

        static void PlaceSheeps(byte n)
        {
            int x = 0;
            int y = 0;
            Console.ForegroundColor = ConsoleColor.White;
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                x = r.Next(1, 80);
                y = r.Next(1, 20);
                Console.SetCursorPosition(x, y);
                Console.Write("x");
            }
            // move sheeps when shooting happens
        }

        static void Shoot()
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(0, 22);
            Console.Write("Shoot:\nX: ");
            byte x = Convert.ToByte(Console.ReadLine());
            Console.Write("Y: ");
            byte y = Convert.ToByte(Console.ReadLine());
            Console.SetCursorPosition(x, y);
            shoot = true;
        }


        static void Main(string[] args)
        {
            DisplayFence('#');
            PlaceSheeps(1);
            Shoot();

            Console.ReadKey();
        }
    }
}
