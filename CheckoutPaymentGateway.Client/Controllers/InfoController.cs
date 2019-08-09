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
    /// <summary>
    /// The Info Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("[controller]")]
    public class InfoController : Controller
    {
        /// <summary>
        /// The configuration object
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="InfoController"/> class.
        /// </summary>
        /// <param name="configuration">The configuration object.</param>
        public InfoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Displays the Index for the Info Controller.
        /// </summary>
        /// <returns>The View</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Submits the specified payment identifier.
        /// </summary>
        /// <param name="paymentId">The payment identifier.</param>
        /// <returns>The Payment Request and Response information</returns>
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