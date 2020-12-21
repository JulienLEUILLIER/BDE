using System;
using System.Collections.Generic;
using System.Text;
using TP8;

namespace TestsUnitaires.DataGenerator
{
    internal static class Clients
    {
        public static Student John()
        {
            return new Student("Doe", "John", 30, 1985);
        }

        public static OtherClient Jane()
        {
            return new OtherClient("Doe", "Jane", 25);
        }

        public static Client Underage()
        {
            return new OtherClient("Thomson", "Timmy", 15);
        }

        public static Client CreateClient(string lastname, string firstname, short age, short year = 0)
        {
            Client newClient;
            if (year == 0)
            {
                newClient = new OtherClient(lastname, firstname, age);
            }
            else
            {
                newClient = new Student(lastname, firstname, age, year);
            }
            return newClient;
        }
    }
}
