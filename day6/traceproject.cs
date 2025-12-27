using System;
struct PriceSnapshot
{
    public string StockSymbol{ get; set; }
    public double StockPrice{ get; set; }
}

abstract class Trade
{
    public int TradeId { get; set; }
    public string StockSymbol { get; set; }
    public int Quantity { get; set; }

    public abstract double CalculateTradeValue();

    public override string ToString()
    {
        return $"TradeId: {TradeId} Symbol: {StockSymbol} Quantity: {Quantity}";
    }
}

class EquityTrade: Trade
{
    public double? MarketPrice{get; set;}
    public override double CalculateTradeValue()
    {
        return Quantity*(MarketPrice ?? 0);
    }
}

static class TradeAnalytics
{
    public static int TotalTrades = 0;
}

class TradeRepository<T> where T:Trade
{
    private List<T> trades = new List<T>();
    public void AddTrade(T trade)
    {
        trades.Add(trade);
        TradeAnalytics.TotalTrades++;
     Console.WriteLine("Trade added successfully");
    }

    public IEnumerable<T> GetAllTrades()
    {
        return trades;
    }
}