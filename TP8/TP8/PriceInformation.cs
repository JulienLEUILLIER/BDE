namespace TP8
{
    public struct PriceInformation
    {
        public readonly decimal _buyPrice;
        public readonly decimal _memberPrice;
        public readonly decimal _notMemberPrice;

        public PriceInformation(decimal buyPrice, decimal memberPrice, decimal notMemberPrice)
        {
            _buyPrice = buyPrice;
            _memberPrice = memberPrice;
            _notMemberPrice = notMemberPrice;
        }
    }
}