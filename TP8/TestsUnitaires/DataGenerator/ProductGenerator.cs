using System;
using System.Collections.Generic;
using System.Text;
using TP8;

namespace TestsUnitaires.DataGenerator
{
    internal class ProductGenerator
    {
        private readonly Commercial _factory;
        private readonly List<ProductInformation> ProductInfos = new List<ProductInformation>();
        internal static Product water, coca, sandwich, veggiesandwich, chips, chocolatebar, cake, beer;

        internal ProductGenerator(Commercial factory)
        {
            _factory = factory;
            SetUpInfos();
            foreach (ProductInformation info in ProductInfos)
            {
                _factory.AddToBrochure(info);
            }
            InitializeProducts();
        }

        internal void InitializeProducts()
        {
            water = _factory.OrderType("water");
            coca = _factory.OrderType("coca");
            sandwich = _factory.OrderType("sandwich");
            veggiesandwich = _factory.OrderType("veggie sandwich");
            chips = _factory.OrderType("chips");
            chocolatebar = _factory.OrderType("chocolate bar");
            cake = _factory.OrderType("cake");
            beer = _factory.OrderType("beer");
        }
        internal void SetUpInfos()
        {
            ProductInfos.Add(new ProductInformation("water", EnumTypeProduct.Beverage, 0.5m, 0.75m, 1.0m));
            ProductInfos.Add(new ProductInformation("chips", EnumTypeProduct.Food, 1.0m, 1.5m, 2.0m));
            ProductInfos.Add(new ProductInformation("beer", EnumTypeProduct.AlcoholicBeverage, 3.0m, 4.0m, 5.0m, true, 5.1f));
            ProductInfos.Add(new ProductInformation("chocolate bar", EnumTypeProduct.Food, 0.5m, 0.75m, 1.0m));
            ProductInfos.Add(new ProductInformation("coca", EnumTypeProduct.Beverage, 0.75m, 1.0m, 1.5m));
            ProductInfos.Add(new ProductInformation("sandwich", EnumTypeProduct.Food, 3.0m, 4.0m, 5.0m, false));
            ProductInfos.Add(new ProductInformation("veggie sandwich", EnumTypeProduct.Food, 4.0m, 5.0m, 6.0m));
            ProductInfos.Add(new ProductInformation("cake", EnumTypeProduct.Food, 2.5m, 4.0m, 5.0m));
        }
    }
}
        
