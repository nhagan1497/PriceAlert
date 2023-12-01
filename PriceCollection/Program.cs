using Microsoft.EntityFrameworkCore.Storage;
using PriceAlertLibrary.DataCollector;
using PriceAlertLibrary.DatabaseHelper;

DataCollector collector = new(new KrakenPriceClient());
IDatabaseHelper db = new PriceAlertDbContext();

decimal price = await collector.GetPriceAsync();
DateTime date = DateTime.Now;

db.AddPrice(date, price);
