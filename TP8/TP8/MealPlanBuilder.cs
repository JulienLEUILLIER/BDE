using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public class MealPlanBuilder
    {
        private IAssembler _assembler;

        public IAssembler Assembler { set { _assembler = value; } }

        public void DessertDrinkMeal(Food food, Beverage beverage)
        {
            _assembler.AddDessert(food);
            _assembler.AddBeverage(beverage);
        }

        public void SandwichBeverageMeal(Food food, Beverage beverage)
        {
            _assembler.AddMainMeal(food);
            _assembler.AddBeverage(beverage);
        }

        public void CompleteMeal(Food mainfood, Food dessertfood, Beverage beverage)
        {
            SandwichBeverageMeal(mainfood, beverage);
            _assembler.AddDessert(dessertfood);
        }

        public void VeggieDessertDrinkMeal(Food food, Beverage beverage)
        {
            _assembler = new MealPlanPreparatorVeggie();
            DessertDrinkMeal(food, beverage);
        }

        public void SaladAndVirginDrink(Food food, Beverage beverage)
        {
            _assembler = new MealPlanPreparatorVeggie();
            _assembler.AddMainMeal(food);
            if (!(beverage is AlcoholicBeverage))
            {
                _assembler.AddBeverage(beverage);
            }
        }

        public void VeggieCompleteMeal(Food mainfood, Food dessertfood, Beverage beverage)
        {
            _assembler = new MealPlanPreparatorVeggie();
            CompleteMeal(mainfood, dessertfood, beverage);
        }
    }
}
