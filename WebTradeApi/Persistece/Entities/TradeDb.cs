using System;
using System.ComponentModel.DataAnnotations;

namespace WebTradeApi.Persistece.Entities
{
    public class TradeDb
    {
        /// <summary> The TradeId field PK.</summary>
        [Key]
        public int TradeId { get; set; }

        /// <summary> The SecurityCode field.</summary>
        public string SecurityCode { get; set; }

        /// <summary> The TradePrice field.</summary>
        public double TradePrice { get; set; }

        /// <summary> The TradeQuantity field.</summary>
        public int TradeQuantity { get; set; }

        /// <summary> The TradeDate field.</summary>
        public DateTime TradeDate { get; set; }

        /// <summary> The TradeBuyer field.</summary>
        public string TradeBuyer { get; set; }


        /// <summary> The Portofolio field.</summary>
        public PortofolioDb Portofolio { get; set; }
    }
}
