using Microsoft.EntityFrameworkCore.Storage;
using PriceAlertLibrary.DataCollector;
using PriceAlertLibrary.DatabaseHelper;

DataCollector collector = new(new KrakenPriceClient());
IDatabaseHelper db = new PriceAlertDbContext();
string apiUrl = "http://price-alert-data-analyzer.azurewebsites.net/api/NewPrice";
while (true)
{
    decimal price = await collector.GetPriceAsync();
    DateTime date = DateTime.Now;

    db.AddPrice(date, price);

    using(HttpClient client = new HttpClient())
    {
        try
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Status Code: {response.StatusCode}");
                Console.WriteLine($"Response Body: {responseBody}");
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }
        finally
        {

        }
    }

    // Wait 15 minutes
    await Task.Delay(900000);
}