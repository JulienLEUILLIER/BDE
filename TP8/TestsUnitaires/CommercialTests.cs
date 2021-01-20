using TestsUnitaires.DataGenerator;
using TP8;
using Xunit;

namespace TestsUnitaires
{
    public class CommercialTests
    {
        private readonly StudentOfficeBuilder builder;
        private readonly StudentOffice office;
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
        public void OrderingIntoStockTest()
        {
            IStockBehaviour stock = office.Stock;
            Commercial commercial = office._commercial;

            stock.AddToStock(commercial.OrderedProduct("chips", 5));
            IStockData stockData = (IStockData)stock;

            Assert.Equal(55, stockData.GetProductQuantity("chips"));
        }
    }
}
