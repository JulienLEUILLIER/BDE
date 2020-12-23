using System;
using System.Collections.Generic;
using System.Text;
using TP8;

namespace TestsUnitaires.DataGenerator
{
    internal class StudentOfficeBuilder
    {
        internal readonly StudentOffice office = new StudentOffice(1000m);
        internal readonly Commercial commercial;
        internal readonly Stock stock;
        internal readonly ProductGenerator products;
        internal readonly MealPlanDirector mealPlanBuilder;
        internal Client john = Clients.John();
        internal Client jane = Clients.Jane();
        internal Client underage = Clients.Underage();
        
        internal StudentOfficeBuilder()
        {
            commercial = office._commercial;
            stock = office._currentStock;
            products = new ProductGenerator(commercial);
            mealPlanBuilder = new MealPlanDirector();
            products.InitializeProducts();
            InitializeStock();
            office.AddClient(john, 50); office.AddClient(jane, 50);
            stock.Attach(office);
        }

        internal void InitializeStock()
        {
            foreach (ProductInformation info in commercial.Brochure)
            {
                stock.AddProduct(commercial.Order(info._productName), 50);
            }
        }
    }
}
