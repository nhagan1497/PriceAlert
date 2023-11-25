using DataAnalyzer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzer.Mocks
{
    public class MockEmailSender : IEmailSender
    {
        public void SendEmail(string email, string message)
        {
            Console.WriteLine($"{message} sent to {email}");
        }
    }
}
