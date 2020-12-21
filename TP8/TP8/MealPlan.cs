using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public class MealPlan
    {
        public readonly List<Product> MealProducts = new List<Product>();

        public void AddToMeal(Product product)
        {
            MealProducts.Add(product);
        }

        public decimal GetTotalPriceMember()
        {
            return 0;
        }

        public decimal GetTotalPriceNotMember()
        {
            return 0;
        }
    }
}
