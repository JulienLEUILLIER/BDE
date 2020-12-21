using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public abstract class Product : IPackaging
    {
        public readonly string _productName;
        public readonly decimal _buyPrice;
        public readonly decimal _memberPrice;
        public readonly decimal _notMemberPrice;
        public string Packaging { get; set; }
        protected Product(ProductInformation info)
        {
            _productName = info._productName;
            _buyPrice = info._buyPrice;
            _memberPrice = info._memberPrice;
            _notMemberPrice = info._notMemberPrice;
        }
    }
}
