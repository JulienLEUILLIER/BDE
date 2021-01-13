using TestsUnitaires.DataGenerator;
using TP8;
using Xunit;
using NSubstitute;
using TestsUnitaires.Fakes;

namespace TestsUnitaires
{
    public class FakeMockTests
    {
        [Fact]
        public void TestStockedOrder()
        {
            // Testing the repository correctly stores the orders when adding to stock
            var repoMock = Substitute.For<IOrderingRepository>();
            Stock stock = new Stock(100m, repoMock);
            Order order = new Order(ProductGenerator.water, 5);

            stock.AddToStock(order);

            repoMock.Received().SaveOrder(order);
        }
    }
}
