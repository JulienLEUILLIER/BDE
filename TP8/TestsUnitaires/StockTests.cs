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
            Product water = sut.GetProductByName("water");

            sut.SubstractProduct(water, 5, john);

            Assert.Equal(45, sut._StockProduct[water]);
        }

        [Fact]
        public void TestPackaging()
        {
            Assert.Equal("Bottle", ProductGenerator.beer.Packaging);
            Assert.Equal("Paper bag", ProductGenerator.chips.Packaging);
        }
    }
}
