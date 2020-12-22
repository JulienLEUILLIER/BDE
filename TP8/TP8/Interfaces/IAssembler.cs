using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public interface IAssembler
    {
        void AddMainMeal(Food food);
        void AddBeverage(Beverage beverage);
        void AddDessert(Food food);
    }
}
