using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TP8
{
    public class Commercial
    {
        public readonly HashSet<ProductInformation> Brochure = new HashSet<ProductInformation>();

        public void AddToBrochure(ProductInformation productinfo)
        {
            Brochure.Add(productinfo);
        }
        public Product OrderType(string productname)
        {
            ProductInformation productInformation = 
                Brochure.FirstOrDefault(pr => pr._productName.ToUpper().Equals(productname.ToUpper()));

                return productInformation._typeProduct switch
                {
                    EnumTypeProduct.Beverage => new Beverage(productInformation),
                    EnumTypeProduct.Food => new Food(productInformation),
                    EnumTypeProduct.AlcoholicBeverage => new AlcoholicBeverage(productInformation),
                    _ => throw new NotImplementedException(),
                };            
        }

        public Order OrderedProduct(string productName, int quantity)
        {
            return new Order(OrderType(productName), quantity);
        }

        public void AddToStock(Stock stock, Order order)
        {
            stock.Repository.SaveOrder(order);

            stock.AddProduct(order);
        }
    }
}
