using System;
using CheckoutPaymentGateway.Enums;
using CheckoutPaymentGateway.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CheckoutPaymentGateway.Models
{
    /// <summary>
    /// An implementation of the Payment Response structure
    /// </summary>
    /// <seealso cref="CheckoutPaymentGateway.Interfaces.IPaymentResponse" />
    public class PaymentResponse : IPaymentResponse
    {
        /// <inheritdoc />
        public Guid Id { get; set; }

        /// <inheritdoc />
        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }
    }
}