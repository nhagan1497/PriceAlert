using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceAlertLibrary.DatabaseHelper.Models
{
    [PrimaryKey(nameof(Date))]
    public class BitcoinPrice
    {
        public BitcoinPrice() { }
        public BitcoinPrice(DateTime date, decimal price)
        {
            Date = date;
            Price = price;
        }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
    }
}
