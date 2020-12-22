using TestsUnitaires.DataGenerator;
using TP8;
using Xunit;

namespace TestsUnitaires
{
    public class CommercialTests
    {
        private readonly StudentOffice office;
        private readonly ProductGenerator generator;
        private readonly Client ofAge = Clients.Jane();
        private readonly Client underAge = Clients.Underage();

        public CommercialTests()
        {
            office = new StudentOffice();
            generator = new ProductGenerator();
        }
        [Fact]
        public void CanOrderBeverage()
        {
            Product water = generator.Water();

            Assert.IsType<Beverage>(water);
            Assert.IsNotType<AlcoholicBeverage>(water);
        }
        [Fact]
        public void CanOrderFood()
        {
            Product chips = generator.Chips();

            Assert.IsType<Food>(chips);
            Assert.IsNotType<AlcoholicBeverage>(chips);
        }
        [Fact]
        public void CanOrderAlcoholicBeverage()
        {
            Product beer = generator.Beer();

            Assert.IsType<AlcoholicBeverage>(beer);
            Assert.IsNotType<Food>(beer);
        }

        [Fact]
        public void CanBuyAlcoholOrNot()
        {
            Product beer = generator.Beer();

            Assert.True(ofAge.CanBuy(beer));
            Assert.False(underAge.CanBuy(beer));
        }

        [Fact]
        public void OrderingIntoStockTest()
        {
            Stock stock = office._currentStock;
            Product chips = generator.Chips();

            generator.factory.AddToStock(office, chips, 5);

            Assert.Equal(5, stock._StockProduct[chips]);
        }
    }
}
