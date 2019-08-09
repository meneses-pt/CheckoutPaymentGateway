using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CheckoutPaymentGateway.Client.Helpers;
using CheckoutPaymentGateway.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CheckoutPaymentGateway.Client.Controllers
{
    [Route("[controller]")]
    public class InfoController : Controller
    {
        private readonly IConfiguration _configuration;

        public InfoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Submit")]
        public async Task<IActionResult> Submit(Guid paymentId)
        {
            var accessToken = AuthenticationHelper.GetAccessToken();

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Get, $"{_configuration["Api:Endpoint"]}/PaymentGateway/{paymentId}"))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                using (var response = await client
                    .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                    .ConfigureAwait(false))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        ViewBag.Response = "Error";
                        return View("Index", null);
                    }

                    var data = await response.Content.ReadAsStringAsync();
                    var paymentResponse = JsonConvert.DeserializeObject<PaymentInfo>(data);

                    ViewBag.Response = paymentResponse;
                }

                return View("Index", null);
            }
        }
    }
}