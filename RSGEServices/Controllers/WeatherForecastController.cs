using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NtosService;

namespace RSGEServices.Controllers
{
    [ApiController]
    [Route("api/weatherForecast")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("get")]
        public async void Get()
        {
            //var services = new WayBillsSoapClient(EndpointConfiguration.WayBillsSoap12);
            //what_is_my_ipResponse test = await services.what_is_my_ipAsync();

            //var test1 = await services.get_waybill_typesAsync("26001004282:206322102", "123456");
            //string jsonText = JsonConvert.SerializeXmlNode(test1.Body.get_waybill_typesResult);

            var user = new get_ser_usersRequest("26001004282:206322102", "123456");


            var services = new NtosServiceSoapClient(NtosServiceSoapClient.EndpointConfiguration.NtosServiceSoap12);

            var test1 = await services.get_ser_usersAsync(user);
            //string jsonText = JsonConvert.SerializeXmlNode(test1.get_ser_usersResult.Any);

            //var test = await services.get_ser_usersAsync(); //783,135184, 

            //გადამხდელის უნიკალური ნომერი 731937

            //var test2 = await services.get_invoice_descAsync(783, 179445179, user.user_name,user.user_password); მუშაობს

            //var t1 = new get_un_id_from_tinRequest(783, "206322102", user.user_name, user.user_password);
            //var test01 = await services.get_un_id_from_tinAsync(t1);
            //var satestoM = await services.get_invoice_numbersAsync(783, 731937, "4", 100,
            //    "26001004282:206322102", "123456");

            //var test2 = await services.get_invoice_numbersAsync(810377, 1243416, "", 100,
            //    "service:01002002543", "NewPass1");
            var satestoM = await services.get_buyer_invoices_rAsync(783, 731937, 1, "26001004282:206322102",
                                                        "123456");
            var test2 = await services.get_buyer_invoices_rAsync(783, 731937, 1,
                                                            "service:01002002543",
                                                          "NewPass1");


            //string jsonText = JsonConvert.SerializeXmlNode(test2);

        }
    }
}
