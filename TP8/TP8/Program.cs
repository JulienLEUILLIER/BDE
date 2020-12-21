using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock();
            Commercial factory = new Commercial();
            ProductInformation info = new ProductInformation("chips", EnumTypeProduct.Food, 1.0m, 2.0m, 3.0m);
            Product prod = factory.GetProduct(info);
            stock.AddProduct(prod, 5);
            Console.WriteLine(stock._StockProduct[prod]);
        }
    }
}
