using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceAlertLibrary.DataCollector
{
    public interface IApiPriceClient
    {
        public Task<decimal> GetPriceAsync();
    }
}
