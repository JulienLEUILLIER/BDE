using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public class MealPlanDirector
    {
        private IAssembler _assembler;

        public IAssembler Assembler { get => _assembler; set => _assembler = value; }

        public void DessertDrinkMeal(Product food, Product beverage)
        {
            _assembler.AddDessert(food);
            _assembler.AddBeverage(beverage);
        }

        public void SandwichBeverageMeal(Product food, Product beverage)
        {
            _assembler.AddMainMeal(food);
            _assembler.AddBeverage(beverage);
        }

        public void CompleteMeal(Product mainfood, Product dessertfood, Product beverage)
        {
            SandwichBeverageMeal(mainfood, beverage);
            _assembler.AddDessert(dessertfood);
        }

        public void VeggieDessertDrinkMeal(Product food, Product beverage)
        {
            _assembler = new MealPlanConcreteBuilderVeggie();
            DessertDrinkMeal(food, beverage);
        }

        public void SaladAndVirginDrink(Product food, Product beverage)
        {
            _assembler = new MealPlanConcreteBuilderVeggie();
            _assembler.AddMainMeal(food);
            if (!(beverage is AlcoholicBeverage))
            {
                _assembler.AddBeverage(beverage);
            }
        }

        public void VeggieCompleteMeal(Product mainfood, Product dessertfood, Product beverage)
        {
            CompleteMeal(mainfood, dessertfood, beverage);
        }
    }
}
