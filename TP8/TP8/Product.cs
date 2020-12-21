using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public abstract class Product
    {
        public readonly string _productName;
        public readonly PriceInformation _priceInformation;

        protected Product(string productName, PriceInformation priceInformation)
        {
            _productName = productName;
            _priceInformation = priceInformation;
        }
    }
}
