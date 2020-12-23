using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TP8
{
    public class Commercial
    {
        public readonly HashSet<ProductInformation> Brochure = new HashSet<ProductInformation>();
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

        public void AddToBrochure(ProductInformation productinfo)
        {
            Brochure.Add(productinfo);
        }

        public void AddToStock(StudentOffice office, Product product, int quantity)
        {
            Stock stock = office._currentStock;

            stock.AddProduct(product, quantity);
        }
    }
}
