using System;
using System.Collections.Generic;
// using ll;
// using cl;
class Program
{
    static void Main()
    {
        // StockPrice st = new StockPrice
        // {
        //     stockSymbol = "AAPQ",
        //     quantiry = 12222
        // };
        // st.display();
        // StockPrice cp = st;
        // cp.quantiry = 1200;
        // cp.display();
        // st.display();


        
        //  SP sts = new SP
        // {
        //     stockSymbol = "AAPQ",
        //     quantiry = 12222
        // };
        // sts.display();
        // SP cps = sts;
        // cps.quantiry = 1200;
        // cps.display();
        // sts.display();

        // Repository<SP> repo = new Repository<SP>();
        // repo.Data = new SP
        // {
        //    stockSymbol = "AAPL",
        //    quantiry = 1500
        // };
        // Console.WriteLine(repo.Data.stockSymbol);
        // Console.WriteLine(repo.Data.quantiry);
        // Calculator calc = new Calculator();
        // int result = calc.Calculate(10, 20);
        // Console.WriteLine(result);
        // String dresult = calc.Calculate("as", "as");
        // Console.WriteLine(dresult);

        //task 1 =====================================
        PriceSnapshot snapshot = new PriceSnapshot
        {
            StockSymbol = "AAPL",
            StockPrice = 150.50
        };
        
        Console.WriteLine($"Stock Symbol: {snapshot.StockSymbol}");
        Console.WriteLine($"Stock Price: {snapshot.StockPrice}");
        EquityTrade ss = new EquityTrade
        {
            TradeId = 1,
            StockSymbol = "AAPQ",
            MarketPrice =150,
            Quantity = 100
        };
        Console.WriteLine(ss.ToString());
        Console.WriteLine(ss.CalculateTradeValue());
    }
}