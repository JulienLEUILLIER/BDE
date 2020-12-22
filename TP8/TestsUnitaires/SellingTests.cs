using TestsUnitaires.DataGenerator;
using TP8;
using Xunit;

namespace TestsUnitaires
{
    public class SellingTests
    {
        private readonly StudentOfficeBuilder builder;
        private readonly StudentOffice sut;
        private readonly Client john = Clients.John();
        private readonly Client jane = Clients.Jane();
        private readonly ProductGenerator generator;
        private readonly Product chips;

        
        public SellingTests()
        {
            builder = new StudentOfficeBuilder();
            sut = builder.office;



            sut.SellProduct(john, chips, 5);
            sut.SellProduct(jane, chips, 3);
        }

        [Fact]
        public void GetRightPrice()
        {
            decimal priceStudent = john.GetAppropriatePrice(chips);
            decimal priceOther = jane.GetAppropriatePrice(chips);

            Assert.Equal(1.5m, priceStudent);
            Assert.Equal(2.0m, priceOther);
        }
        [Fact]
        public void StockChangeTest()
        {
            Assert.Equal(42, sut._currentStock._StockProduct[chips]);
        }
        [Fact]
        public void ClientBalanceChangeTest()
        {
            Assert.Equal(12.5m, sut._ClientList[john]);
            Assert.Equal(24m, sut._ClientList[jane]);
        }

        [Fact]
        public void StudentOfficeBalanceChangeTest()
        {
            Assert.Equal(63.5m, sut._currentStock.CurrentBalance);
        }
    }
}
