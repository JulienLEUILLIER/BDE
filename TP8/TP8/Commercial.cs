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
                EnumTypeProduct.Beverage => new Beverage(productname, productInformation._priceInformation),
                EnumTypeProduct.Food => new Food(productname, productInformation._priceInformation),
                EnumTypeProduct.AlcoholicBeverage => new AlcoholicBeverage(productname, productInformation._priceInformation, productInformation._alcoholDegree),
                _ => throw new NotImplementedException(),
            };
        }

        public void AddProduct(string productName, EnumTypeProduct typeProduct, PriceInformation priceInformation, float alcoholdegree)
        {
            ProductInformation productInformation = new ProductInformation(productName, typeProduct, priceInformation, alcoholdegree);
            Brochure.Add(productInformation);
        }

        public void AddToStock(StudentOffice office, string productName, int quantity)
        {
            Stock stock = office._currentStock;
            Product orderedProduct = Order(productName);
            stock.AddProduct(orderedProduct, quantity);
        }
    }
}
