using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TP8
{
    public class MealPlan : ISellable
    {
        public readonly List<Product> MealProducts = new List<Product>();

        public decimal BuyPrice { get; }

        public decimal MemberPrice { get; }

        public decimal NotMemberPrice { get; }

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
            return MealProducts.Sum(product => product.GetTotalPriceMember());
        }

        public decimal GetTotalPriceNotMember()
        {
            return MealProducts.Sum(product => product.GetTotalPriceNotMember());
        }
    }
}
