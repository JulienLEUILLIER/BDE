using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public abstract class Product : IPackaging, ISellable
    {
        public string _name { get; }
        public decimal BuyPrice { get; }
        public decimal MemberPrice { get; }
        public decimal NotMemberPrice { get; }

        public bool _isVeggie;

        public string Packaging { get; set; }
        protected Product(ProductInformation info)
        {
            _name = info._productName;
            BuyPrice = info._buyPrice;
            MemberPrice = info._memberPrice;
            NotMemberPrice = info._notMemberPrice;
            _isVeggie = info._isVeggie;
        }

        public decimal GetTotalPriceMember()
        {
            return MemberPrice;
        }

        public decimal GetTotalPriceNotMember()
        {
            return NotMemberPrice;
        }
    }
}
