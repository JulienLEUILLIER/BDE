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


        [Fact]
        public void NotifyingTestMock()
        {
            var stock = Substitute.For<IStockBehaviour>();
            var sut = new StudentOffice(stock);
            Order order = new Order(ProductGenerator.chips, 5);

            stock.AddToStock(order);

            stock.Received().Notify(order._product);
        }
    }
}
