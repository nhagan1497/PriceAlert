using PriceAlertLibrary.DataCollector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryUnitTests.Mocks
{
    public class MockPriceClient : IApiPriceClient
    {
        private decimal NextPrice { get; set; }

        public MockPriceClient()
        {
            NextPrice = 0.0m;
        }

        public void SetNextPrice(decimal price) { NextPrice = price; }
        public async Task<decimal> GetPriceAsync()
        {
            return await Task.FromResult(NextPrice);
        }
    }
}
