using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PriceAlertLibrary.DataAnalyzer;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NotificationServer
{
    [Route("api/NewPrice")]
    [ApiController]
    public class AnalyzerController : ControllerBase
    {
        private readonly DataAnalyzer _analyzer;
        public AnalyzerController(DataAnalyzer analyzer)
        {
            _analyzer = analyzer;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _analyzer.UpdateAlerts();
            _analyzer.SendEmails();

            return Ok("Alerts sent!");
        }


    }

    [Route("api/metrics")]
    [ApiController]
    public class MetricsController : ControllerBase
    {

        [HttpGet("health")]
        public IActionResult Get()
        {
            return Ok();
        }


    }


}
