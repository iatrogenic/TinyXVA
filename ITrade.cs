namespace TinyXVA;

public interface ITrade
{
    public GenericTradeInfo TradeInfo { get; }
}

public class GenericTradeInfo(string dealId, string counterparty)
{
    public string DealId { get; set; } = dealId;
    public string Counterparty { get; set; } = counterparty;
}