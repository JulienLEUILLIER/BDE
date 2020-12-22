using System;
using System.Collections.Generic;
using System.Text;
using TP8;

namespace TestsUnitaires.DataGenerator
{
    internal class StudentOfficeBuilder
    {
        internal readonly StudentOffice office = new StudentOffice(500m);
        internal readonly Commercial commercial;
        internal readonly Stock stock;
        internal readonly ProductGenerator products;
        internal readonly MealPlanBuilder mealPlanBuilder;
        internal Client john = Clients.John();
        internal Client jane = Clients.Jane();
        internal Client underage = Clients.Underage();
        
        internal StudentOfficeBuilder()
        {
            commercial = office._commercial;
            stock = office._currentStock;
            products = new ProductGenerator(commercial);
            products.InitializeProducts();
        }

        internal void InitializeStock()
        {
            foreach (ProductInformation info in commercial.Brochure)
            {
                commercial.AddToStock(office, commercial.Order(info._productName), 50);
            }
        }
    }
}
