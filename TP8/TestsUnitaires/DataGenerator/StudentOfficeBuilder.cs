using System;
using System.Collections.Generic;
using System.Text;
using TP8;

namespace TestsUnitaires.DataGenerator
{
    internal class StudentOfficeBuilder
    {
        internal readonly StudentOffice office;
        internal readonly Commercial commercial;
        internal readonly IStockBehaviour stock;
        internal readonly ProductGenerator products;
        internal readonly MealPlanDirector mealPlanBuilder;
        internal Client john = Clients.John();
        internal Client jane = Clients.Jane();
        internal Client underage = Clients.Underage();
        
        internal StudentOfficeBuilder()
        {
            office = new StudentOffice(new Stock(1000m, new OrderingRepository()));
            commercial = office._commercial;
            stock = office.Stock;
            products = new ProductGenerator(commercial);
            mealPlanBuilder = new MealPlanDirector();
            InitializeStock();
            office.AddClient(john, 50); office.AddClient(jane, 50);
            stock.Attach(office);
        }

        internal void InitializeStock()
        {
            foreach (ProductInformation info in commercial.Brochure)
            {
                stock.AddToStock(commercial.OrderedProduct(info._productName, 50));
            }
        }
    }
}
