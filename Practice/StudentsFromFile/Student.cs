using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_StudentsFromFile_OOP2
{
    class Student
    {
        public string Name { get; set; }
        public double Average { get; set; }

        public Student(string _name, double _average)
        {
            Name = _name;
            Average = _average;
        }
    }
}
