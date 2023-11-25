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
        public DataCollector(IApiPriceClient apiClient)
        {
            ApiClient = apiClient;
        }

        private IApiPriceClient ApiClient { get; }

        public async Task<decimal> GetPriceAsync()
        {
            return await ApiClient.GetPriceAsync();
        }
    }
}
