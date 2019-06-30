using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hunting {
    class Program {
        static bool shoot = false;
        static bool gameRunning = true;

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

        static void PlaceSheep()
        {
            int x = 0;
            int y = 0;
            Console.ForegroundColor = ConsoleColor.White;
            Random r = new Random();

            x = r.Next(1, 80);
            y = r.Next(1, 20);
            Console.SetCursorPosition(x, y);
            Console.Write("x");

            // move sheeps when shooting happens

            do
            {
                if (shoot)
                {
                    Random d = new Random();
                    int direction = d.Next(1, 5);
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ");
                    switch (direction)
                    {
                        case 1:
                            Console.SetCursorPosition(x++, y);
                            Console.Write("x");
                            break;
                        case 2:
                            Console.SetCursorPosition(x--, y);
                            Console.Write("x");
                            break;
                        case 3:
                            Console.SetCursorPosition(x, y++);
                            Console.Write("x");
                            break;
                        case 4:
                            Console.SetCursorPosition(x, y++);
                            Console.Write("x");
                            break;
                                                                                                        
                    }

                }
            } while (gameRunning);
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
            PlaceSheep();
            Shoot();
            
            Console.ReadKey();
        }
    }
}
