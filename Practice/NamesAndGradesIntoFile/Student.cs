using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_namesAndGradesIntoFile
{
    class Student
    {
        

        public string Name { get; set; }
        public double Average { get; set; }

        public Student(string name, double average)
        {
            Name = name;
            Average = average;
        }

    }
}
