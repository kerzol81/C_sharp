using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _01_StudentsFromFile_OOP2
{
    class Program
    {
        static string[] ReadIntoArray(string filename)
        {
            if (File.Exists(filename))
            {
                string[] data = File.ReadAllLines(filename, Encoding.UTF8);
                return data;
            }
            return null;
        }

        private static double Average(Student[] students)
        {
            double total = 0;
            for (int i = 0; i < students.Length; i++)
            {
                total += students[i].Average;
            }
            return (total * 1.0) / students.Length;
        }

        private static string Best(Student[] students) {
            Student best = students[0];
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].Average > best.Average)
                {
                    best = students[i];
                }
            }
            return best.Name;
        }

        private static string Worst(Student[] students) {
            Student worst = students[0];
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].Average < worst.Average)
                {
                    worst = students[i];
                }
            }
            return worst.Name;
        }

        static void Main(string[] args)
        {
            string[] student_data = ReadIntoArray("names.txt");

            Student[] students = new Student[student_data.Length / 2];

            for (int i = 0, n = 0, a = 1; i < student_data.Length && n <= student_data.Length && a <= student_data.Length; i++, n += 2, a += 2)
            {
                Student s = new Student(student_data[n], Convert.ToDouble(student_data[a]));
                students[i] = s;
            }

            Console.WriteLine(Average(students));
            Console.WriteLine(Best(students));
            Console.WriteLine(Worst(students));

            Console.ReadKey();
        }
       
    }
}
