using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHelper
{
    public interface IDatabaseHelper
    {
        void AddPrice(DateTime date, decimal price);
        decimal GetPrice(DateTime date);
        public List<(string, decimal, decimal)> GetEmailAlerts(decimal currentPrice);
        void UpdateAlert(string email, decimal oldHighPrice, decimal newHighPrice, decimal newLowPrice);
    }
}
