using System;
using System.Collections.Generic;
using System.Text;
using TP8;

namespace TestsUnitaires.DataGenerator
{
    internal class ProductGenerator
    {
        internal Commercial factory;

        internal ProductGenerator()
        {
            factory = new Commercial();
        }
        internal ProductInformation InfoWater()
        {
            return new ProductInformation("eau", EnumTypeProduct.Beverage, 0.5m, 0.75m, 1.0m);
        }

        internal ProductInformation InfoChips()
        {
            return new ProductInformation("chips", EnumTypeProduct.Food, 1.0m, 1.5m, 2.0m);
        }

        internal ProductInformation InfoBeer()
        {
            return new ProductInformation("beer", EnumTypeProduct.AlcoholicBeverage, 3.0m, 4.0m, 5.0m, true, 5.1f);
        }

        internal Product Water()
        {
            return factory.GetProduct(InfoWater());
        }

        internal Product Chips()
        {
            return factory.GetProduct(InfoChips());
        }

        internal Product Beer()
        {
            return factory.GetProduct(InfoBeer());
        }
    }
}
