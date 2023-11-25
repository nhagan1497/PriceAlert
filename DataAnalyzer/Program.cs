using DataAnalyzer.Mocks;
using DatabaseHelper;

MockEmailSender mockEmailSender = new();
PostgresHelper db = new();

DataAnalyzer.DataAnalyzer dataAnalyzer = new(mockEmailSender, db);

dataAnalyzer.UpdateAlerts();
dataAnalyzer.SendEmails();