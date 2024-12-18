namespace TinyXVA;

public class InterestRateSwap : ITrade
{
    public double Maturity { get; set; }
    public double SwapRateSpread { get; set; }
    public double FixedLegCoupon { get; set; }
    public double Notional {get; set;}
    public double RiskFreeIr { get; set; }
    public double Coupon { get; set; }
    public double DayCountFaction { get; set; }

    public InterestRateSwap(double maturity,
        double swapRateSpread,
        double fixedLegCoupon,
        double notional,
        double riskFreeIr,
        double coupon,
        double dayCountFaction,
        GenericTradeInfo tradeInfo)
    {
        Maturity = maturity;
        SwapRateSpread = swapRateSpread;
        FixedLegCoupon = fixedLegCoupon; 
        Notional = notional;
        RiskFreeIr = riskFreeIr;
        Coupon = coupon;
        DayCountFaction = dayCountFaction;
        TradeInfo = tradeInfo;
    }

    public GenericTradeInfo TradeInfo { get; }
}