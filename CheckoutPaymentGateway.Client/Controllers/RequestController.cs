using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CheckoutPaymentGateway.Client.Helpers;
using CheckoutPaymentGateway.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CheckoutPaymentGateway.Client.Controllers
{
    [Route("[controller]")]
    public class RequestController : Controller
    {
        private readonly IConfiguration _configuration;

        public RequestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Submit")]
        public async Task<IActionResult> Submit(PaymentRequest paymentRequest)
        {
            var accessToken = AuthenticationHelper.GetAccessToken();

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, $"{_configuration["Api:Endpoint"]}/PaymentGateway/"))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var json = JsonConvert.SerializeObject(paymentRequest);
                using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    request.Content = stringContent;

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
                        var paymentResponse = JsonConvert.DeserializeObject<PaymentResponse>(data);

                        ViewBag.Response = paymentResponse;
                    }

                    return View("Index", null);
                }
            }
        }
    }
}