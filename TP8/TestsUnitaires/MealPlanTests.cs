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
        private StudentOfficeBuilder sut;

        public MealPlanTests()
        {
            sut = new StudentOfficeBuilder();
        }

        [Fact]
        public void AddingMealComponentTest()
        {
            MealPlanPreparator preparator = new MealPlanPreparator();

            preparator.AddBeverage(sut.products.beer);
            
            Assert.Single(preparator._mealplan.MealProducts);
        }

        [Fact]
        public void SettingUpMealPlan()
        {

        }
    }
}
