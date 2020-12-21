using System;
using System.Collections.Generic;
using System.Text;
using TP8;

namespace TestsUnitaires.DataGenerator
{
    internal static class Products
    {
        internal static PriceInformation WaterPrice()
        {
            return new PriceInformation(0.5m, 0.75m, 1.0m);
        }        
        internal static PriceInformation ChipsPrice()
        {
            return new PriceInformation(0.5m, 1.0m, 1.25m);
        }        
        internal static PriceInformation BeerPrice()
        {
            return new PriceInformation(2.0m, 3.0m, 4.0m);
        }
        internal static Beverage Water()
        {
            return new Beverage("Water", WaterPrice());
        }

        internal static Food Chips()
        {
            return new Food("Chips", ChipsPrice());
        }

        internal static AlcoholicBeverage Beer()
        {
            return new AlcoholicBeverage("Beer", BeerPrice(), 5.1f);
        }
    }
}
