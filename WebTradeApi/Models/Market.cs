using System.ComponentModel.DataAnnotations;

namespace WebTradeApi.Models
{
    /// <summary> The Trade class.</summary>
    public class Market
    {
        /// <summary> The SecurityCode field.</summary>
        [StringLength(4, ErrorMessage = "The SecurityCode value cannot exceed 4 characters.")]
        [RegularExpression(@"[A-Z]{1,4}",
         ErrorMessage = "Characters are not allowed.")]
        public string SecurityCode { get; set; }

        /// <summary> The MarketPrice field.</summary>
        public decimal MarketPrice { get; set; }
    }
}
