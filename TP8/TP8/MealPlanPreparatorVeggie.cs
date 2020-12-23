using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public class MealPlanConcreteBuilderVeggie : IAssembler
    {
        public MealPlan _mealplan = new MealPlan();

        public MealPlanConcreteBuilderVeggie()
        {
            Reset();
        }

        public void Reset()
        {
            _mealplan = new MealPlan();
        }
        public void AddDessert(Product food)
        {
            if (food._isVeggie)
            {
                _mealplan.AddToMeal(food);
            }
        }

        public void AddMainMeal(Product food)
        {
            if (food._isVeggie)
            {
                _mealplan.AddToMeal(food);
            }
        }
        public void AddBeverage(Product beverage)
        {
            _mealplan.AddToMeal(beverage);
        }

        public MealPlan GetMealPlan()
        {
            MealPlan mealplan = this._mealplan;

            this.Reset();

            return mealplan;
        }
    }
}
