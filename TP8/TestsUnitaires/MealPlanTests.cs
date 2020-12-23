using System;
using System.Collections.Generic;
using System.Text;
using TestsUnitaires.DataGenerator;
using TP8;
using Xunit;

namespace TestsUnitaires
{
    public class MealPlanTests
    {
        private readonly StudentOfficeBuilder office;
        private readonly MealPlanDirector sut;
        private readonly MealPlanConcreteBuilder preparator;
        private readonly ProductGenerator products;

        public MealPlanTests()
        {
            office = new StudentOfficeBuilder();
            sut = new MealPlanDirector();
            preparator = new MealPlanConcreteBuilder();
            sut.Assembler = preparator;
            products = office.products;
        }

        [Fact]
        public void AddingMealComponentTest()
        {
            // Testing if products are correctly added to meal plan
            preparator.AddBeverage(office.products.beer);
            
            Assert.Single(preparator._mealplan.MealProducts);
        }

        [Fact]
        public void ResettingMealPlan()
        {
            // Testing if resetting the meal plan after getting it works correctly
            preparator.AddBeverage(office.products.beer);

            var mealplan = preparator.GetMealPlan();

            Assert.Empty(preparator._mealplan.MealProducts);
        }

        [Fact]
        public void SettingUpMealPlan()
        {
            // Testing if the complete meal gets back a meal plan of 3 products
            sut.CompleteMeal(products.sandwich, products.chocolatebar, products.water);

            MealPlan mealPlan = preparator.GetMealPlan();

            Assert.Equal(3, mealPlan.MealProducts.Count);
        }

        [Fact]
        public void CheckingVeggieMeal()
        {
            sut.VeggieCompleteMeal(products.veggiesandwich, products.chocolatebar, products.water);

            MealPlan mealPlan = preparator.GetMealPlan();

            Assert.Equal(3, mealPlan.MealProducts.Count);
        }
    }
}
