using PriceAlertLibrary.DataAnalyzer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryUnitTests.Mocks
{
    public class MockEmailer : IEmailer
    {
        public List<(string, string)> SentEmails = new();
        public void SendEmail(string email, string message)
        {
            SentEmails.Add((email, message));
        }
    }
}
