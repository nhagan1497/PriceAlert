using PriceAlertLibrary.DataCollector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PriceAlertLibrary.DataCollector
{
    public class KrakenPriceClient : IApiPriceClient
    {
        public KrakenPriceClient()
        {

        }

        public async Task<decimal> GetPriceAsync()
        {
            string publicResponse = "";
            string publicEndpoint = "Ticker";
            string publicInputParameters = "pair=xbtusd";
            publicResponse = await QueryPublicEndpoint(publicEndpoint, publicInputParameters);

            // Parse the JSON string
            var jsonDocument = JsonDocument.Parse(publicResponse);

            // Access the result node
            var resultNode = jsonDocument.RootElement.GetProperty("result");

            // Access the XXBTZUSD node
            var xxBtzUsdNode = resultNode.GetProperty("XXBTZUSD");

            // Access the c array within XXBTZUSD
            var cArray = xxBtzUsdNode.GetProperty("c").EnumerateArray();

            // Access the dollar value (assuming it's the first element in the c array)
            var dollarValue = cArray.First().GetString();

            try
            {
                return decimal.Parse(dollarValue!);
            }
            catch
            {
                return -1m;
            }
        }

        private static async Task<string> QueryPublicEndpoint(string endpointName, string inputParameters)
        {
            string jsonData;
            string baseDomain = "https://api.kraken.com";
            string publicPath = "/0/public/";
            string apiEndpointFullURL = baseDomain + publicPath + endpointName + "?" + inputParameters;
            using (HttpClient client = new HttpClient())
            {
                jsonData = await client.GetStringAsync(apiEndpointFullURL);
            }
            return jsonData;
        }
    }
}
