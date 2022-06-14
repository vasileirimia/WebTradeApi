using System.ComponentModel.DataAnnotations;

namespace WebTradeApi.Persistece.Entities
{
    public class MarketDb
    {
        /// <summary> The SecurityCode field.</summary>
        [Key]
        public string SecurityCode { get; set; }

        /// <summary> The MarketPrice field.</summary>
        public double MarketPrice { get; set; }
    }
}
