using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceAlertLibrary.DataAnalyzer
{
    public class Emailer : IEmailer
    {
        public void SendEmail(string email, string message)
        {
            Console.WriteLine($"{message} sent to {email}");
        }
    }
}
