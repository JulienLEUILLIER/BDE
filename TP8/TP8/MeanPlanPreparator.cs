using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public class MealPlanPreparator : IAssembler
    {
        protected MealPlan _mealplan = new MealPlan();

        public MealPlanPreparator()
        {
            Reset();
        }

        public void Reset()
        {
            _mealplan = new MealPlan();
        }

        public virtual void AddMainMeal(Food food)
        {
            _mealplan.AddToMeal(food);
        }

        public void AddBeverage(Beverage beverage)
        {
            _mealplan.AddToMeal(beverage);
        }

        public virtual void AddDessert(Food food)
        {
            _mealplan.AddToMeal(food);
        }
    }
}
