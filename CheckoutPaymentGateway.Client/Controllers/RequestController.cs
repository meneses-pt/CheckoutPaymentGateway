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
    /// <summary>
    /// The Request Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("[controller]")]
    public class RequestController : Controller
    {
        /// <summary>
        /// The configuration object
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestController"/> class.
        /// </summary>
        /// <param name="configuration">The configuration object.</param>
        public RequestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Displays the Index for the Configuration Controller.
        /// </summary>
        /// <returns>The View</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Submits the specified payment request.
        /// </summary>
        /// <param name="paymentRequest">The payment request.</param>
        /// <returns>The View with the Payment Response</returns>
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