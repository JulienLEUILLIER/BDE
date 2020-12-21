using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public class AlcoholicBeverage : Beverage
    {
        public readonly float _alcoholDegree;
        public AlcoholicBeverage(ProductInformation info) : base(info)
        {
            _alcoholDegree = info._alcoholDegree;
        }
    }
}
