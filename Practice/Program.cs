using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _03_namesAndGradesIntoFile
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter s = new StreamWriter("names.txt", true, Encoding.UTF8);
            string name;
            double average;

            do
            {
                Console.Write("Name: ");
                name = Console.ReadLine();
                
                
                if (name != "exit")
                {
                    Console.Write("Average: ");
                    average = Convert.ToDouble(Console.ReadLine());
                    Student student = new Student(name, average);
                    s.WriteLine(student.Name);
                    s.WriteLine(student.Average);
                    s.Flush();
                }

            } while (name != "exit");
        }
    }
}
