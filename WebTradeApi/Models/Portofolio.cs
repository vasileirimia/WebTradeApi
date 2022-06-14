using System.Text.Json.Serialization;

namespace WebTradeApi.Models
{
    /// <summary> The Trade class.</summary>
    public class Portofolio
    {
        /// <summary> The PortofolioId field.</summary>
        [JsonIgnore]
        public int PortofolioId { get; set; }

        /// <summary> The HolderName field.</summary>
        public string HolderName { get; set; }

        /// <summary> The PurchaseValue field.</summary>
        public double PurchaseValue { get; set; }

        /// <summary> The MarketValue field.</summary>
        public double MarketValue { get; set; }

        /// <summary> The ProfitOrLoss field.</summary>
        public double ProfitOrLoss { get; set; }
    }
}
