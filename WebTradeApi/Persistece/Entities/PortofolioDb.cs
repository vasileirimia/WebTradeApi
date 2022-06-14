using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebTradeApi.Persistece.Entities
{
    public class PortofolioDb
    {
        /// <summary> The PortofolioId field PK.</summary>
        [Key]
        public int PortofolioId { get; set; }

        /// <summary> The HolderName field.</summary>
        public string HolderName { get; set; }

        /// <summary> The PurchaseValue field.</summary>
        public double PurchaseValue { get; set; }

        /// <summary> The MarketValue field.</summary>
        public double MarketValue { get; set; }

        /// <summary> The ProfitOrLoss field.</summary>
        public double ProfitOrLoss { get; set; }


        /// <summary> 1 Portofolio contains a list of trades.</summary>
        public List<TradeDb> Trades { get; set; }
    }
}
