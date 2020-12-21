using TestsUnitaires.DataGenerator;
using TP8;
using Xunit;

namespace TestsUnitaires
{
    public class SellingTests
    {
        private readonly StudentOffice sut;
        private readonly Client john = Clients.John();
        private readonly Client jane = Clients.Jane();
        private readonly Product chips = Products.Chips();

        
        public SellingTests()
        {
            sut = new StudentOffice();
            sut.AddClient(john, 20m);
            sut.AddClient(jane, 30m);
            sut._currentStock.AddProduct(chips, 50);
            sut.SellProduct(john, chips, 5);
            sut.SellProduct(jane, chips, 3);
        }

        [Fact]
        public void GetRightPrice()
        {
            decimal priceStudent = john.GetAppropriatePrice(chips);
            decimal priceOther = jane.GetAppropriatePrice(chips);

            Assert.Equal(1.0m, priceStudent);
            Assert.Equal(1.25m, priceOther);
        }
        [Fact]
        public void StockChangeTest()
        {
            Assert.Equal(42, sut._currentStock._StockProduct[chips]);
        }
        [Fact]
        public void ClientBalanceChangeTest()
        {
            Assert.Equal(15, sut._ClientList[john]);
            Assert.Equal(26.25m, sut._ClientList[jane]);
        }

        [Fact]
        public void StudentOfficeBalanceChangeTest()
        {
            Assert.Equal(83.75m, sut._currentStock.CurrentBalance);
        }
    }
}
