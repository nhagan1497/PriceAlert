using DatabaseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzerUnitTest.Mocks
{
    internal class MockDatabase : IDatabaseHelper
    {
        private List<(string, decimal, decimal)>? EmailAlerts;
        private decimal Price;

        public void SetEmailAlerts(List<(string, decimal, decimal)> emailAlerts)
        {
            EmailAlerts = emailAlerts;
        }

        public void SetPrice(decimal price) { Price = price; }

        public void AddPrice(DateTime date, decimal price)
        {
            
        }

        public List<(string, decimal, decimal)> GetEmailAlerts(decimal currentPrice)
        {
            return EmailAlerts!;
        }

        public decimal GetPrice(DateTime date)
        {
            return Price;
        }

        public void UpdateAlert(string email, decimal oldHighPrice, decimal newHighPrice, decimal newLowPrice)
        {
            
        }
    }
}
