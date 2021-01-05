using TestsUnitaires.DataGenerator;
using TP8;
using Xunit;
using System.Linq;
using Moq;
using NSubstitute;

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
        public void NotifyingTest()
        {
            var officeMock = new Mock<ISubscriber>();
            IStockBehaviour stock = new Stock(500m, new OrderingRepository());
            stock.Attach(officeMock.Object);
            stock.AddToStock(new Order(ProductGenerator.chips, 11));

            officeMock.Setup(o => o.SellProduct(Clients.John(), new Order(ProductGenerator.chips, 2)));

            officeMock.Verify(o => o.Update(It.IsAny<Product>()));
        }

        [Fact]
        public void OtherTest()
        {
            var stockMock = Substitute.For<ISubscriber>();
            IStockBehaviour stock = new Stock(500m, new OrderingRepository());
            stock.Attach(stockMock);
            stock.AddToStock(new Order(ProductGenerator.chips, 11));

            stockMock.SellProduct(Clients.John(), new Order(ProductGenerator.chips, 2));

            stockMock.Received().Update(ProductGenerator.chips);
        }
    }
}
