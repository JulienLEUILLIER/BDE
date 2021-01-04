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
        private readonly Client john, jane, underage;
        public ClientTests()
        {
            john = Clients.John();
            jane = Clients.Jane();
            underage = Clients.Underage();
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
            // Check if the appropriate price is returned
            var water = ProductGenerator.water;

            Assert.Equal(0.75m, john.GetAppropriatePrice(water));
            Assert.Equal(1.0m, jane.GetAppropriatePrice(water));
        }

        [Fact]
        public void CanBuyAlcoholOrNot()
        {
            // Checking if client can buy alcohol
            var beer = ProductGenerator.beer;

            Assert.True(john.CanBuy(beer));  // age 30
            Assert.False(underage.CanBuy(beer)); // age 15
        }

        [Fact]
        public void TestOperatorEqual()
        {
            // Test of the == and != overrided operators for client

            StudentOffice office = new StudentOffice();
            Client sameJohn = office.CreateClient("DOE", "john", 30, 1985);

            Assert.True(john == sameJohn);
            Assert.True(john != jane);
        }
    }
}
