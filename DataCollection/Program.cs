using DataCollection;
using DatabaseHelper;

DataCollector collector = new DataCollector(new KrakenPriceClient());
IDatabaseHelper db = new PostgresHelper();

while (true)
{
    decimal price = await collector.GetPriceAsync();
    DateTime date = DateTime.Now;

    Console.WriteLine(db.GetPrice(DateTime.Now));
    db.AddPrice(date, price);
    await Task.Delay(60000);
}