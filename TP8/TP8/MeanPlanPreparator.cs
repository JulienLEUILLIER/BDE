using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public class MealPlanPreparator : IAssembler
    {
        public MealPlan _mealplan = new MealPlan();

        public MealPlanPreparator()
        {
            Reset();
        }

        public void Reset()
        {
            _mealplan = new MealPlan();
        }

        public virtual void AddMainMeal(Product food)
        {
            _mealplan.AddToMeal(food);
        }

        public void AddBeverage(Product beverage)
        {
            _mealplan.AddToMeal(beverage);
        }

        public virtual void AddDessert(Product food)
        {
            _mealplan.AddToMeal(food);
        }

        public MealPlan GetMealPlan()
        {
            MealPlan mealplan = this._mealplan;

            this.Reset();

            return mealplan;
        }
    }
}
