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
            return new Student("DOe", "JoHn", 30, 1985);
        }

        public static OtherClient Jane()
        {
            return new OtherClient("Doe", "Jane", 25);
        }

        public static Client Underage()
        {
            return new OtherClient("Thomson", "Timmy", 15);
        }
    }
}
