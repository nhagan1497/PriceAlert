using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceAlertLibrary.DatabaseHelper.Models
{
    public class BitcoinPriceAlert
    {
        public BitcoinPriceAlert() { }
        public BitcoinPriceAlert(string email, decimal highPrice, decimal lowPrice) {
            Email = email;
            HighPrice = highPrice;
            LowPrice = lowPrice;
        }
        
        public int Id { get; set; }

        public string? Email { get; set; }

        public decimal HighPrice { get; set; }

        public decimal LowPrice { get; set; }
    }
}
