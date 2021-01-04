using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TP8;
using TestsUnitaires.DataGenerator;

namespace TestsUnitaires
{
    public class ClientTests
    {
        private readonly Client john, jane;
        public ClientTests()
        {
            john = Clients.John();
            jane = Clients.Jane();
        }

        [Fact]
        public void TestFormatName()
        {
            // Testing formatting name

            Assert.Equal("DOE John", john.GetName());
        }

        [Fact]
        public void GetRightPrice()
        {
            var water = ProductGenerator.water;

            Assert.Equal(0.75m, john.GetAppropriatePrice(water));
            Assert.Equal(1.0m, jane.GetAppropriatePrice(water));
        }
    }
}
