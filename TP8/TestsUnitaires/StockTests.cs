using TestsUnitaires.DataGenerator;
using Xunit;
using TP8;

namespace TestsUnitaires
{
    public class StockTests
    {
        private readonly Stock sut;
        private readonly Product chips = Products.Chips();
        private readonly Client john = Clients.John();

        public StockTests()
        {
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
    }
}
