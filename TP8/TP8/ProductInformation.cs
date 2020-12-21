using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public class ProductInformation
    {
        public string _productName;
        public EnumTypeProduct _typeProduct;
        public readonly decimal _buyPrice;
        public readonly decimal _memberPrice;
        public readonly decimal _notMemberPrice;
        public float _alcoholDegree;
        public bool _isVeggie;

        public ProductInformation(string productName, EnumTypeProduct typeProduct, 
            decimal buyPrice, decimal memberPrice, decimal notMemberPrice, bool isVeggie = true, float alcoholDegree = 0)
        {
            _productName = productName;
            _typeProduct = typeProduct;
            _buyPrice = buyPrice;
            _memberPrice = memberPrice;
            _notMemberPrice = notMemberPrice;
            _alcoholDegree = alcoholDegree;
            _isVeggie = isVeggie;
        }
    }
}
