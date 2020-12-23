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
        private readonly StudentOfficeBuilder builder;
        private readonly MealPlanDirector sut;
        private readonly MealPlanConcreteBuilder preparator;
        private readonly MealPlanConcreteBuilderVeggie veggiepreparator;
        private readonly ProductGenerator products;
        private readonly Client john;

        public MealPlanTests()
        {
            builder = new StudentOfficeBuilder();
            sut = new MealPlanDirector();
            preparator = new MealPlanConcreteBuilder();
            veggiepreparator = new MealPlanConcreteBuilderVeggie();
            sut.Assembler = preparator;
            products = builder.products;
            john = builder.john;
        }

        [Fact]
        public void AddingMealComponentTest()
        {
            // Testing if products are correctly added to meal plan
            preparator.AddBeverage(builder.products.beer);
            
            Assert.Single(preparator._mealplan.MealProducts);
        }

        [Fact]
        public void ResettingMealPlan()
        {
            // Testing if resetting the meal plan after getting it works correctly

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
            sut.Assembler = veggiepreparator;
            sut.VeggieCompleteMeal(products.veggiesandwich, products.chocolatebar, products.water);

            MealPlan mealPlan = veggiepreparator.GetMealPlan();

            Assert.Equal(3, mealPlan.MealProducts.Count);
        }

        [Fact]
        public void MealPlanSellingTest()
        {
            sut.CompleteMeal(products.sandwich, products.chocolatebar, products.water);
            StudentOffice studentoffice = builder.office;

            studentoffice.SellMealPlan(preparator, john);

            Assert.Equal(44.5m, studentoffice._ClientList[john]);
        }
    }
}
