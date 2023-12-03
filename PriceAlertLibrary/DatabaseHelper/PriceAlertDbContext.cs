using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PriceAlertLibrary.DatabaseHelper.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using PriceAlertLibrary.DatabaseHelper;

namespace PriceAlertLibrary.DatabaseHelper
{
    public class PriceAlertDbContext : DbContext, IDatabaseHelper
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=price-alert-db.postgres.database.azure.com;Port=5432;Username=price;Password=price;Database=pricealert");
        }

        public DbSet<BitcoinPrice> BitcoinPrices { get; set; }
        public DbSet<BitcoinPriceAlert> BitcoinPriceAlerts { get; set; }

        public void AddPrice(DateTime date, decimal price)
        {
            BitcoinPrice bitcoinPrice = new(date, price);
            BitcoinPrices.Add(bitcoinPrice);
            SaveChanges();
        }

        public List<(string, decimal, decimal)> GetEmailAlerts(decimal currentPrice)
        {
            var matchingAlerts = BitcoinPriceAlerts
                .Where(alert => currentPrice < alert.LowPrice || currentPrice > alert.HighPrice)
                .Select(alert => new { alert.Email, alert.HighPrice, alert.LowPrice })
                .ToList();

            return matchingAlerts
            .Select(alert => (alert.Email, alert.HighPrice, alert.LowPrice))
            .ToList();
        }

        public decimal GetPrice(DateTime date)
        {
            decimal latestPrice = BitcoinPrices
                .Where(bitcoinPrice => bitcoinPrice.Date <= date)
                .OrderByDescending(bitcoinPrice => bitcoinPrice.Date)
                .Select(bitcoinPrice => bitcoinPrice.Price)
                .FirstOrDefault();

            return latestPrice;
        }

        public void UpdateAlert(string email, decimal oldHighPrice, decimal newHighPrice, decimal newLowPrice)
        {
            var alertToUpdate = BitcoinPriceAlerts
            .FirstOrDefault(alert => alert.Email == email && alert.HighPrice == oldHighPrice);

            if (alertToUpdate != null)
            {
                alertToUpdate.HighPrice = newHighPrice;
                alertToUpdate.LowPrice = newLowPrice;

                SaveChanges();
            }
        }
    }
}
