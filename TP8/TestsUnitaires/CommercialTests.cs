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

        public CommercialTests()
        {
            commercial = new Commercial();
            office = new StudentOffice();
        }

        [Fact]
        public void CanOrderBeverage()
        {            
            commercial.AddProduct("water", EnumTypeProduct.Beverage, Products.WaterPrice(), 0);

            Assert.IsType<Beverage>(commercial.Order("water"));
            Assert.IsNotType<AlcoholicBeverage>(commercial.Order("water"));
        }
        [Fact]
        public void CanOrderFood()
        {
            commercial.AddProduct("chips", EnumTypeProduct.Food, Products.ChipsPrice(), 0);

            Assert.IsType<Food>(commercial.Order("chips"));
            Assert.IsNotType<AlcoholicBeverage>(commercial.Order("chips"));
        }
        [Fact]
        public void CanOrderAlcoholicBeverage()
        {
            commercial.AddProduct("beer", EnumTypeProduct.AlcoholicBeverage, Products.BeerPrice(), 5.1f);

            Assert.IsType<AlcoholicBeverage>(commercial.Order("beer"));
            Assert.IsNotType<Food>(commercial.Order("beer"));
        }

        [Fact]
        public void CanBuyAlcoholOrNot()
        {
            commercial.AddProduct("beer", EnumTypeProduct.AlcoholicBeverage, Products.BeerPrice(), 5.1f);

            Assert.True(ofAge.CanBuy(commercial.Order("beer")));
            Assert.False(underAge.CanBuy(commercial.Order("beer")));
        }

        [Fact]
        public void OrderingIntoStockTest()
        {
            commercial.AddProduct("chips", EnumTypeProduct.Food, Products.ChipsPrice(), 0);
            Stock stock = office._currentStock;

            commercial.AddToStock(office, "chips", 5);
            Product chips = stock.GetProductByName("chips");

            Assert.Equal(5, stock._StockProduct[chips]);
        }
    }
}
