using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TP8
{
    public class Commercial
    {
        private readonly HashSet<ProductInformation> Brochure = new HashSet<ProductInformation>();
        public Product Order(string productname)
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

        public void AddProduct(ProductInformation productinfo)
        {
            Brochure.Add(productinfo);
        }

        public void AddToStock(StudentOffice office, string productName, int quantity)
        {
            Stock stock = office._currentStock;
            Product orderedProduct = Order(productName);
            stock.AddProduct(orderedProduct, quantity);
        }

        public Product GetProduct(ProductInformation info)
        {
            this.AddProduct(info);
            return this.Order(info._productName);
        }
    }
}
