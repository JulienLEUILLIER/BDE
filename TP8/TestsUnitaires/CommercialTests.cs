using TestsUnitaires.DataGenerator;
using TP8;
using Xunit;

namespace TestsUnitaires
{
    public class CommercialTests
    {
        private readonly StudentOfficeBuilder builder;
        private readonly StudentOffice office;
        private readonly ProductGenerator generator;
        private readonly Client ofAge = Clients.Jane();
        private readonly Client underAge = Clients.Underage();
        private readonly Product water, chips, beer;

        public CommercialTests()
        {
            builder = new StudentOfficeBuilder();
            office = builder.office;
            generator = new ProductGenerator(office._commercial);
            water = builder.products.water; chips = builder.products.chips; beer = builder.products.beer;
        }
        [Fact]
        public void CanOrderBeverage()
        {
            Assert.IsType<Beverage>(water);
            Assert.IsNotType<AlcoholicBeverage>(water);
        }
        [Fact]
        public void CanOrderFood()
        {
            Assert.IsType<Food>(chips);
            Assert.IsNotType<AlcoholicBeverage>(chips);
        }
        [Fact]
        public void CanOrderAlcoholicBeverage()
        {
            Assert.IsType<AlcoholicBeverage>(beer);
            Assert.IsNotType<Food>(beer);
        }

        [Fact]
        public void CanBuyAlcoholOrNot()
        {
            Assert.True(ofAge.CanBuy(beer));
            Assert.False(underAge.CanBuy(beer));
        }

        [Fact]
        public void OrderingIntoStockTest()
        {
            Stock stock = office._currentStock;

            office._commercial.AddToStock(office, chips, 5);

            Assert.Equal(5, stock._StockProduct[chips]);
        }
    }
}
