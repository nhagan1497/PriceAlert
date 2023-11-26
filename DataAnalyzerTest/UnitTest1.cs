using DataAnalyzerUnitTest.Mocks;

namespace DataAnalyzerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EmailAlertsTest()
        {
            MockDatabase db = new();
            MockEmailer emailer = new();
            List<(string, decimal, decimal)> emailAlerts = new();
            emailAlerts.Add(("test@example.com", 15000m, 10000m));
            emailAlerts.Add(("test2@example.com", 30000m, 25000m));
            db.SetPrice(20000m);
            db.SetEmailAlerts(emailAlerts);

            DataAnalyzer.DataAnalyzer analyzer = new(emailer, db);
            analyzer.UpdateAlerts();
            analyzer.SendEmails();

            string email, message;
            (email, message) = emailer.SentEmails[0];
            Assert.IsTrue(email == "test@example.com" && message == "The price of bitcoin just hit 20000!");
            (email, message) = emailer.SentEmails[1];
            Assert.IsTrue(email == "test2@example.com" && message == "The price of bitcoin just hit 20000!");
        }
    }
}