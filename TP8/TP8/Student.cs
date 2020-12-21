using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public class Student : Client
    {
        public readonly short _degreeYear;
        public Student(string name, string surname, short age, short degreeYear) : base(name, surname, age)
        {
            _degreeYear = degreeYear;
        }

        
    }
}
