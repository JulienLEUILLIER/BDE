using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public class AlcoholicBeverage : Beverage
    {
        public readonly float _alcoholDegree;

        public AlcoholicBeverage(string productName, PriceInformation priceInformation, float alcoholDegree) : base(productName, priceInformation)
        {
            _alcoholDegree = alcoholDegree;
        }
    }
}
