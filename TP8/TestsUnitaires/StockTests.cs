using TestsUnitaires.DataGenerator;
using Xunit;
using TP8;

namespace TestsUnitaires
{
    public class StockTests
    {
        private StudentOfficeBuilder builder;
        private readonly Stock sut;
        private readonly Client john;
        private readonly Product chips, beer;

        public StockTests()
        {
            builder = new StudentOfficeBuilder();
            sut = builder.office._currentStock;
            john = builder.john;
            chips = builder.products.chips; beer = builder.products.beer;
        }
        [Fact]
        public void GetTheRightProduct()
        {
            Assert.Equal(chips, sut.GetProductByName("chips"));
        }
        [Fact]
        public void GetTheRightQuantity()
        {
            Assert.Equal(10, sut.GetProductQuantity("chips"));
        }
        [Fact]
        public void TestSubstractingProduct()
        {
            sut.SubstractProduct(chips, 5, john);

            Assert.Equal(5, sut._StockProduct[chips]);
        }

        [Fact]
        public void TestPackaging()
        {
            Assert.Equal("Bottle", beer.Packaging);
            Assert.Equal("Paper bag", chips.Packaging);
        }
    }
}
