using TestsUnitaires.DataGenerator;
using Xunit;
using TP8;

namespace TestsUnitaires
{
    public class StockTests
    {
        private readonly Stock sut;
        private readonly ProductGenerator generator = new ProductGenerator();
        private readonly Product chips;
        private readonly Product beer;
        private readonly Client john = Clients.John();

        public StockTests()
        {
            chips = generator.Chips();
            beer = generator.Beer();
            sut = new Stock();
            sut.AddProduct(chips, 10);
        }
        [Fact]
        public void GetTheRightProduct()
        {
            Assert.Equal(chips, sut.GetProductByName(chips._productName));
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
