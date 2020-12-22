using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public class MealPlanPreparatorVeggie : MealPlanPreparator
    {
        public override void AddDessert(Product food)
        {
            if (food._isVeggie)
            {
                base.AddDessert(food);
            }
        }

        public override void AddMainMeal(Product food)
        {
            if (food._isVeggie)
            {
                base.AddMainMeal(food);
            }
        }
    }
}
