using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebTradeApi.Persistece.Entities;

namespace WebTradeApi.Persistece.Repository
{
    public class AggregateRepository : IAggregateRepository
    {
        public async Task<PortofolioDb> BuildPortofolio(PortofolioDb portofolioDb, DbSet<MarketDb> marketUpdates)
        {
            double tradePriceSum = 0.0;
            double marketValueSum = 0.0;

            foreach (TradeDb tradeDb in portofolioDb.Trades)
            {
                tradePriceSum += tradeDb.TradePrice * tradeDb.TradeQuantity;
                double marketPrice = await GetMarketPrice(tradeDb.SecurityCode, marketUpdates).ConfigureAwait(false);
                marketValueSum += marketPrice * tradeDb.TradeQuantity;
            }

            portofolioDb.PurchaseValue = tradePriceSum;
            portofolioDb.MarketValue = marketValueSum;
            portofolioDb.ProfitOrLoss = portofolioDb.MarketValue - portofolioDb.PurchaseValue;

            return portofolioDb;
        }

        private async Task<double> GetMarketPrice(string securityCode, DbSet<MarketDb> marketUpdates)
        {
            var marketUpdate = await marketUpdates.SingleOrDefaultAsync(m => m.SecurityCode == securityCode).ConfigureAwait(false);

            return marketUpdate.MarketPrice;
        }
    }
}
