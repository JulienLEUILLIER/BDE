using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public class ProductInformation
    {
        public string _productName;
        public EnumTypeProduct _typeProduct;
        public PriceInformation _priceInformation;
        public float _alcoholDegree;

        public ProductInformation(string productName, EnumTypeProduct typeProduct, PriceInformation priceInformation, float alcoholDegree)
        {
            _productName = productName;
            _typeProduct = typeProduct;
            _priceInformation = priceInformation;
            _alcoholDegree = alcoholDegree;
        }
    }
}
