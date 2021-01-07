namespace TP8
{
    public interface ISellable
    {
        decimal BuyPrice { get; }
        decimal MemberPrice { get; }
        decimal NotMemberPrice { get; }

        decimal GetTotalPriceMember();
        decimal GetTotalPriceNotMember();
    }
}