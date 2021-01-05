using TestsUnitaires.DataGenerator;
using Xunit;
using TP8;

namespace TestsUnitaires
{
    public class StockTests
    {
        private readonly StudentOfficeBuilder builder;
        private readonly IStockData sut;
        private readonly Client john;

        public StockTests()
        {
            builder = new StudentOfficeBuilder();
            sut = (IStockData)builder.office._stock;
            john = builder.john;
        }

        [Fact]
        public void GetTheRightQuantity()
        {
            Assert.Equal(50, sut.GetProductQuantity("chips"));
        }
        [Fact]
        public void TestSubstractingProduct()
        {
            Order waterOrder = new Order(sut.GetProductByName("water"), 5);
            IStockBehaviour publisher = (IStockBehaviour)sut;

            publisher.SellingOperations(john.GetAppropriatePrice(waterOrder._product), waterOrder);

            Assert.Equal(45, sut.StockProduct[waterOrder._product]);
        }

        [Fact]
        public void TestPackaging()
        {
            Assert.Equal("Bottle", ProductGenerator.beer.Packaging);
            Assert.Equal("Paper bag", ProductGenerator.chips.Packaging);
        }
    }
}
