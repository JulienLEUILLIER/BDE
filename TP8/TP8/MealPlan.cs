using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
            //decimal price = 0;
            //foreach (Product product in MealProducts)
            //{
            //    price += product._memberPrice;
            //}
            //return price;
            return MealProducts.Sum(product => product._memberPrice);
        }

        public decimal GetTotalPriceNotMember()
        {
            return MealProducts.Sum(product => product._notMemberPrice);
        }
    }
}
