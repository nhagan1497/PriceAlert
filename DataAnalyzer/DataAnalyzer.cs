using DataAnalyzer.Interfaces;
using DatabaseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzer
{
    public class DataAnalyzer
    {
        IEmailSender _emailSender;
        IDatabaseHelper _databaseHelper;
        List<(string, decimal)> EmailAlerts;

        public DataAnalyzer(IEmailSender emailSender, IDatabaseHelper databaseHelper)
        {
            _emailSender = emailSender;
            _databaseHelper = databaseHelper;
            EmailAlerts = new List<(string, decimal)>();
        }

        public void UpdateAlerts()
        {
            decimal currentPrice = _databaseHelper.GetPrice(DateTime.Now);
            var alerts = _databaseHelper.GetEmailAlerts(currentPrice);

            foreach((string email, decimal highValue, decimal lowValue) in alerts)
            {
                EmailAlerts.Add((email, currentPrice));

                decimal oldPrice = (highValue + lowValue) / 2;
                decimal spread = oldPrice - lowValue;
                _databaseHelper.UpdateAlert(email, highValue, currentPrice + spread, currentPrice - spread);
            }
        }

        public void SendEmails()
        {
            foreach ((string email, decimal price) in EmailAlerts)
            {
                string message = $"The price of bitcoin just hit {price}!";
                _emailSender.SendEmail(email, message);
            }
        }

    }
}
