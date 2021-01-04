using TestsUnitaires.DataGenerator;
using TP8;
using Xunit;
using System.Linq;

namespace TestsUnitaires
{
    public class FakeTests
    {
        [Fact]
        public void TestStockedOrder()
        {
            // Testing the repository correctly stores the orders when adding to stock
            IOrderingRepository repository = new FakeOrderingRepository();
            Stock stock = new Stock(100m, repository);
            Order order = new Order(ProductGenerator.water, 5);

            stock.AddToStock(order);

            Assert.True(repository.OrdersPassed.First().Equals(order));
        }
    }
}
