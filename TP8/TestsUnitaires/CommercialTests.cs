using TestsUnitaires.DataGenerator;
using TP8;
using Xunit;

namespace TestsUnitaires
{
    public class CommercialTests
    {
        private readonly StudentOfficeBuilder builder;
        private readonly StudentOffice office;
        private readonly Client ofAge = Clients.Jane();
        private readonly Client underAge = Clients.Underage();
        private readonly Product water, chips, beer;

        public CommercialTests()
        {
            builder = new StudentOfficeBuilder();
            office = builder.office;
            water = ProductGenerator.water; chips = ProductGenerator.chips; beer = ProductGenerator.beer;
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
            Stock stock = office._stock;
            Commercial commercial = office._commercial;

            stock.AddToStock(stock.Repository, commercial.OrderedProduct("chips", 5));

            Assert.Equal(55, stock.GetProductQuantity("chips"));
        }
    }
}
