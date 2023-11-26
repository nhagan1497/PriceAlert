using DataCollection;

namespace DataCollectionUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task GetPriceTest()
        {
            decimal nextPrice = 10000m;
            MockPriceClient priceClient = new MockPriceClient();
            priceClient.SetNextPrice(nextPrice);

            DataCollector collector = new(priceClient);
            Assert.AreEqual(nextPrice, await collector.GetPriceAsync());
        }

        [TestMethod]
        public async Task FailedGetPriceTest()
        {
            decimal nextPrice = 10000m;
            MockPriceClient priceClient = new MockPriceClient();
            DataCollector collector = new(priceClient);

            priceClient.SetNextPrice(nextPrice);
            _ = collector.GetPriceAsync();
            priceClient.SetNextPrice(-1m);
            Assert.AreEqual(nextPrice, await collector.GetPriceAsync());
        }


    }
}