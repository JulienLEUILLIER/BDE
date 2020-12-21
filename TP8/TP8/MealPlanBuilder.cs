using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public class MealPlanBuilder
    {
        private IAssembler _assembler;

        public IAssembler Assembler { set { _assembler = value; } }

        public void DessertDrinkMeal()
        {
            _assembler.AddDessert();
            _assembler.AddBeverage();
        }

        public void SandwichBeverageMeal()
        {
            _assembler.AddMainMeal();
            _assembler.AddBeverage();
        }

        public void CompleteMeal()
        {
            SandwichBeverageMeal();
            _assembler.AddDessert();
        }
    }
}
