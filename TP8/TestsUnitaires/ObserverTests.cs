using System;
using System.Collections.Generic;
using System.Text;
using TestsUnitaires.DataGenerator;
using TP8;
using Xunit;

namespace TestsUnitaires
{
    public class ObserverTests
    {
        private StudentOfficeBuilder office;

        public ObserverTests()
        {
            office = new StudentOfficeBuilder();
        }
    }
}
