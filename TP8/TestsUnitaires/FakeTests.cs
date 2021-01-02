using System;
using System.Collections.Generic;
using System.Text;
using TestsUnitaires.DataGenerator;
using TP8;
using Xunit;
using NSubstitute;
using System.Linq;

namespace TestsUnitaires
{
    public class FakeTests
    {
        [Fact]
        public void TestStockedOrder()
        {
            IOrderingRepository repository = new InMemoryOrderingRepository();
            Stock stock = new Stock(100m, repository);
            Order order = new Order(ProductGenerator.water, 5);
            Commercial commercial = new Commercial();

            commercial.AddToStock(stock, order);

            Assert.True(repository.OrdersPassed.First().Equals(order));
        }
    }
}
