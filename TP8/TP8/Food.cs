using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public class Food : Product
    {
        public new readonly bool _isVeggie;
        public Food(ProductInformation info) : base(info)
        {
            _isVeggie = info._isVeggie;
            Packaging = "Paper bag";
        }
    }
}
