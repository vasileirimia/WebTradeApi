using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebTradeApi.Models
{
    /// <summary> The Trade class.</summary>
    public class Trade
    {
        /// <summary> The TradeId field.</summary>
        [JsonIgnore]
        public int TradeId { get; set; }

        /// <summary> The SecurityCode field.</summary>
        [StringLength(4, ErrorMessage = "The SecurityCode value cannot exceed 4 characters.")]
        [RegularExpression(@"[A-Z]{1,4}",
         ErrorMessage = "Only uppercase letters allowed.")]
        public string SecurityCode { get; set; }

        /// <summary> The TradePrice field.</summary>
        public decimal TradePrice { get; set; }

        /// <summary> The TradeQuantity field.</summary>
        public int TradeQuantity { get; set; }

        /// <summary> The TradeDate field.</summary>
        public DateTime TradeDate { get; set; }

        /// <summary> The TradeBuyer field.</summary>
        [Required(ErrorMessage = "TradeBuyer is required")]
        public string TradeBuyer { get; set; }
    }
}
