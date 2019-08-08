using System;
using System.Net;
using CheckoutPaymentGateway.Interfaces;
using CheckoutPaymentGateway.Models;
using Microsoft.AspNetCore.Mvc;

namespace CheckoutPaymentGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentGatewayController : ControllerBase
    {
        private readonly IPaymentGateway _paymentGateway;
        
        public PaymentGatewayController(IPaymentGateway paymentGateway)
        {
            _paymentGateway = paymentGateway;
        }

        // GET get a previous payment request
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            try
            {
                var response = _paymentGateway.RetrievePayamentInfo(id);
                if (response == null)
                {
                    return StatusCode((int)HttpStatusCode.NotFound);
                }
                return StatusCode((int)HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
        }

        // POST Make a new Payment Request
        [HttpPost]
        public ActionResult Post([FromBody] PaymentRequest request)
        {
            try
            {
                var response = _paymentGateway.ProcessPayment(request);
                if (response == null)
                {
                    return StatusCode((int)HttpStatusCode.NotFound);
                }
                return StatusCode((int) HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
        }
    }
}