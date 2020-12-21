using TestsUnitaires.DataGenerator;
using TP8;
using Xunit;

namespace TestsUnitaires
{
    public class CommercialTests
    {
        private readonly Commercial commercial;
        private readonly StudentOffice office;
        private readonly Client ofAge = Clients.Jane();
        private readonly Client underAge = Clients.Underage();
        private readonly Product water;
        private readonly Product chips;
        private readonly Product beer;

        public CommercialTests()
        {
            commercial = new Commercial();
            office = new StudentOffice();
            commercial.AddProduct("water", EnumTypeProduct.Beverage, Products.WaterPrice(), 0);
            commercial.AddProduct("chips", EnumTypeProduct.Food, Products.ChipsPrice(), 0);
            commercial.AddProduct("beer", EnumTypeProduct.AlcoholicBeverage, Products.BeerPrice(), 5.1f);
            water = commercial.Order("water");
            chips = commercial.Order("chips");
            beer = commercial.Order("beer");
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

            commercial.AddToStock(office, "chips", 5);
            Product chips = stock.GetProductByName("chips");

            Assert.Equal(5, stock._StockProduct[chips]);
        }
    }
}
