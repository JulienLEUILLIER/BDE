namespace TP8
{
    public interface ISellable
    {
        decimal BuyPrice { get; }
        decimal MemberPrice { get; }
        decimal NotMemberPrice { get; }
        string _name { get; }

        decimal GetTotalPriceMember();
        decimal GetTotalPriceNotMember();
    }
}