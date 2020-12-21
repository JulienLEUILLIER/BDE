using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public abstract class Product : IPackaging
    {
        public readonly string _productName;
        public readonly PriceInformation _priceInformation;
        public string Packaging { get; set; }
        protected Product(string productName, PriceInformation priceInformation)
        {
            _productName = productName;
            _priceInformation = priceInformation;
        }
    }
}
