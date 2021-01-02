using TestsUnitaires.DataGenerator;
using TP8;
using Xunit;

namespace TestsUnitaires
{
    public class SellingTests
    {
        private readonly StudentOfficeBuilder builder;
        private readonly StudentOffice sut;
        private readonly Client john, jane;

        
        public SellingTests()
        {
            builder = new StudentOfficeBuilder();
            sut = builder.office;
            john = builder.john; jane = builder.jane;
            sut.SellProduct(john, ProductGenerator.chips, 5);
            sut.SellProduct(jane, ProductGenerator.chips, 3);
        }

        [Fact]
        public void GetRightPrice()
        {
            // Get the right price based on the type of buyer, student or not
            decimal priceStudent = john.GetAppropriatePrice(ProductGenerator.chips);
            decimal priceOther = jane.GetAppropriatePrice(ProductGenerator.chips);

            Assert.Equal(1.5m, priceStudent);
            Assert.Equal(2.0m, priceOther);
        }
        [Fact]
        public void StockChangeTest()
        {
            // 8 chips were bought, 50 were there at the start
            Stock stock = sut._currentStock;
            Product stockedChips = stock.GetProductByName("chips");

            Assert.Equal(42, sut._currentStock._StockProduct[stockedChips]);
        }
        [Fact]
        public void ClientBalanceChangeTest()
        {
            // John and Jane had their balance at 50 before the sell
            // Chips are 1.5 for members, 2.0 for non members
            // John bought 5, Jane bought 3
            Assert.Equal(42.5m, sut._ClientList[john]);
            Assert.Equal(44m, sut._ClientList[jane]);
        }

        [Fact]
        public void StudentOfficeBalanceChangeTest()
        {
            // Office balance was 237.5 before the sell
            Assert.Equal(251m, sut._currentStock.CurrentBalance);
        }

        [Fact]
        public void NotifyingTest()
        {
            // Test of the observer pattern : stock was at 42, 40 are sold, 40 are ordered
            sut.SellProduct(john, ProductGenerator.chips, 40);
            Stock stock = sut._currentStock;
            Product stockedChips = stock.GetProductByName("chips");

            Assert.Equal(42, sut._currentStock._StockProduct[stockedChips]);
        }
    }
}
