using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public class Beverage : Product
    {
        public Beverage(ProductInformation info) : base(info)
        {
            Packaging = "Bottle";
        }
    }
}
