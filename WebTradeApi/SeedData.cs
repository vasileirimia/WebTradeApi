using System;
using System.Collections.Generic;
using WebTradeApi.Persistece;
using WebTradeApi.Persistece.Entities;

namespace WebTradeApi
{
    /// <summary> SeedData class.</summary>
    public static class SeedData
    {
        public static void AddTestData(TradeContext context)
        {
            var trades = new List<TradeDb>
            {
                new TradeDb
                {
                    SecurityCode = "MSFT",
                    TradePrice = 10,
                    TradeQuantity = 2,
                    TradeDate= new DateTime(2021, 8, 10),
                    TradeBuyer = "John"
                },
                new TradeDb
                {
                    SecurityCode = "MSFT",
                    TradePrice = 10,
                    TradeQuantity = 3,
                    TradeDate= new DateTime(2021, 8, 10),
                    TradeBuyer = "John"
                },
                new TradeDb
                {
                    SecurityCode = "AAPL",
                    TradePrice = 10,
                    TradeQuantity = 4,
                    TradeDate= new DateTime(2021, 8, 10),
                    TradeBuyer = "John"
                }
            };
            var johnPortofolio = new PortofolioDb { HolderName = "John" };
            johnPortofolio.Trades = new List<TradeDb> { };
            johnPortofolio.Trades.AddRange(trades);
            context.Portofolios.Add(johnPortofolio);

            var aliceTrades = new List<TradeDb>
            {
                new TradeDb
                {
                    SecurityCode = "AAPL",
                    TradePrice = 12,
                    TradeQuantity = 5,
                    TradeDate= new DateTime(2021, 8, 10),
                    TradeBuyer = "Alice"
                }
            };
            var alicePortofolio = new PortofolioDb { HolderName = "Alice" };
            alicePortofolio.Trades = new List<TradeDb> { };
            alicePortofolio.Trades.AddRange(aliceTrades);
            context.Portofolios.Add(alicePortofolio);

            var marketUpdates = new List<MarketDb>
            {
                new MarketDb
                {
                    SecurityCode = "MSFT", MarketPrice = 10
                },
                new MarketDb
                {
                    SecurityCode = "AAPL", MarketPrice = 10
                }
            };
            context.MarketUpdates.AddRange(marketUpdates);

            context.SaveChanges();
        }
    }
}
