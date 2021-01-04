using TestsUnitaires.DataGenerator;
using Xunit;
using TP8;

namespace TestsUnitaires
{
    public class StockTests
    {
        private readonly StudentOfficeBuilder builder;
        private readonly Stock sut;
        private readonly Client john;

        public StockTests()
        {
            builder = new StudentOfficeBuilder();
            sut = builder.office._stock;
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

            sut.SubstractProduct(waterOrder, john);

            Assert.Equal(45, sut._StockProduct[waterOrder._product]);
        }

        [Fact]
        public void TestPackaging()
        {
            Assert.Equal("Bottle", ProductGenerator.beer.Packaging);
            Assert.Equal("Paper bag", ProductGenerator.chips.Packaging);
        }
    }
}
