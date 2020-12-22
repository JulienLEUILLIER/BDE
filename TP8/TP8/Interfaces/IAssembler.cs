using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public interface IAssembler
    {
        void AddMainMeal(Product food);
        void AddBeverage(Product beverage);
        void AddDessert(Product food);

        MealPlan GetMealPlan();
    }
}
