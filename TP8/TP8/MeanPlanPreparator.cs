using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public class MealPlanPreparator : IAssembler
    {
        private MealPlan _mealplan = new MealPlan();

        public MealPlanPreparator()
        {
            Reset();
        }

        public void Reset()
        {
            _mealplan = new MealPlan();
        }

        public void AddMainMeal()
        {

        }

        public void AddBeverage()
        {

        }

        public void AddDessert()
        {

        }
    }
}
