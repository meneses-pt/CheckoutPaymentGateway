﻿using System;
using System.Net;
using CheckoutPaymentGateway.Interfaces;
using CheckoutPaymentGateway.Models;
using Microsoft.AspNetCore.Mvc;

namespace CheckoutPaymentGateway.Controllers
{
    /// <summary>
    /// Controller on which Payment requests can be made.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentGatewayController : ControllerBase
    {
        private readonly IPaymentGateway _paymentGateway;

        /// <summary>Initializes a new instance of the <see cref="PaymentGatewayController"/> class.</summary>
        /// <param name="paymentGateway">The payment gateway.</param>
        public PaymentGatewayController(IPaymentGateway paymentGateway)
        {
            _paymentGateway = paymentGateway;
        }

        /// <summary>Gets information for a specific Payment Request.</summary>
        /// <param name="id">The Payment Request Identifier.</param>
        /// <returns>The Payment Request</returns>
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            try
            {
                var response = _paymentGateway.RetrievePaymentInfo(id);
                if (response == null)
                {
                    return StatusCode((int) HttpStatusCode.NotFound);
                }

                return StatusCode((int) HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode((int) HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Makes a new Payment Request
        /// </summary>
        /// <param name="request">The Payment Request data.</param>
        /// <returns>A Payment Response with its Identifier and Status</returns>
        [HttpPost]
        public ActionResult Post([FromBody] PaymentRequest request)
        {
            try
            {
                var response = _paymentGateway.ProcessPayment(request);
                if (response == null)
                {
                    return StatusCode((int) HttpStatusCode.NotFound);
                }

                return StatusCode((int) HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return StatusCode((int) HttpStatusCode.BadRequest);
            }
        }
    }
}