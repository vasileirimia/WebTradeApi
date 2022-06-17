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
        [Required]
        [StringLength(4, ErrorMessage = "The SecurityCode value cannot exceed 4 characters.")]
        [RegularExpression(@"[A-Z]{1,4}",
         ErrorMessage = "Only uppercase letters allowed.")]
        public string SecurityCode { get; set; }

        /// <summary> The TradePrice field.</summary>
        [Required]
        [RegularExpression(@"^\d+(.\d{0,2})?$")]
        [Range(0, 9999999999.99)]
        public double TradePrice { get; set; }

        /// <summary> The TradeQuantity field.</summary>
        [Range(1, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int TradeQuantity { get; set; }

        /// <summary> The TradeDate field.</summary>x`
        public DateTime TradeDate { get; set; } = DateTime.Now.Date;

        /// <summary> The TradeBuyer field.</summary>
        [Required(ErrorMessage = "TradeBuyer is required")]
        public string TradeBuyer { get; set; }
    }
}
