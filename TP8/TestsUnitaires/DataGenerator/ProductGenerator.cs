using System;
using System.Collections.Generic;
using System.Text;
using TP8;

namespace TestsUnitaires.DataGenerator
{
    internal class ProductGenerator
    {
        private Commercial _factory;
        internal Product water, coca, sandwich, veggiesandwich, chips, chocolatebar, cake, beer;

        internal ProductGenerator(Commercial factory)
        {
            _factory = factory;
        }

        internal void InitializeProducts()
        {
            Water(); Coca(); Sandwich(); VeggieSandwich(); Chips(); ChocolateBar(); Cake(); Beer();
            water = _factory.Order("water");
            coca = _factory.Order("coca");
            sandwich = _factory.Order("sandwich");
            veggiesandwich = _factory.Order("veggiesandwich");
            chips = _factory.Order("chips");
            chocolatebar = _factory.Order("chocolatebar");
            cake = _factory.Order("cake");
            beer = _factory.Order("beer");
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

        internal ProductInformation InfoChocolateBar()
        {
            return new ProductInformation("chocolate bar", EnumTypeProduct.Food, 0.5m, 0.75m, 1.0m);
        }

        internal ProductInformation InfoCoca()
        {
            return new ProductInformation("coca", EnumTypeProduct.Beverage, 0.75m, 1.0m, 1.5m);
        }

        internal ProductInformation InfoSandwich()
        {
            return new ProductInformation("sandwich", EnumTypeProduct.Food, 3.0m, 4.0m, 5.0m, false);
        }
        
        internal ProductInformation InfoVeggieSandwich()
        {
            return new ProductInformation("veggie sandwich", EnumTypeProduct.Food, 4.0m, 5.0m, 6.0m);
        }

        internal ProductInformation InfoCake()
        {
            return new ProductInformation("cake", EnumTypeProduct.Food, 2.5m, 4.0m, 5.0m);
        }

        internal void Water()
        {
            _factory.AddProduct(InfoWater());
        }

        internal void Chips()
        {
            _factory.AddProduct(InfoChips());
        }

        internal void Beer()
        {
            _factory.AddProduct(InfoBeer());
        }

        internal void ChocolateBar()
        {
            _factory.AddProduct(InfoChocolateBar());
        }

        internal void Coca()
        {
            _factory.AddProduct(InfoCoca());
        }

        internal void Sandwich()
        {
            _factory.AddProduct(InfoSandwich());
        }

        internal void VeggieSandwich()
        {
            _factory.AddProduct(InfoVeggieSandwich());
        }

        internal void Cake()
        {
            _factory.AddProduct(InfoCake());
        }
    }
}
