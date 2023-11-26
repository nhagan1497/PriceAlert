using DataCollection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollection
{
    public class DataCollector
    {
        private decimal LastPrice { get; set; }
        public DataCollector(IApiPriceClient apiClient)
        {
            ApiClient = apiClient;
            LastPrice = 0m;
        }

        private IApiPriceClient ApiClient { get; }

        public async Task<decimal> GetPriceAsync()
        {
            decimal clientReturn = await ApiClient.GetPriceAsync();
            if(clientReturn != -1m)
            {
                LastPrice = clientReturn;
            }
            return LastPrice;
        }
    }
}
