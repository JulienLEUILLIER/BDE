using TestsUnitaires.DataGenerator;
using Xunit;
using TP8;

namespace TestsUnitaires
{
    public class StockTests
    {
        private readonly StudentOfficeBuilder builder;
        private readonly Stock sut;
        private readonly ProductGenerator generator;
        private readonly Client john;
        private readonly Product chips, beer;

        public StockTests()
        {
            builder = new StudentOfficeBuilder();
            generator = builder.products;
            sut = builder.office._currentStock;
            john = builder.john;
            chips = generator.chips; beer = generator.beer;
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
            Assert.Equal("Bottle", beer.Packaging);
            Assert.Equal("Paper bag", chips.Packaging);
        }
    }
}
