using DataAnalyzer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzerUnitTest.Mocks
{
    internal class MockEmailer : IEmailSender
    {
        public List<(string, string)> SentEmails = new();
        public void SendEmail(string email, string message)
        {
            SentEmails.Add((email, message));
        }
    }
}
