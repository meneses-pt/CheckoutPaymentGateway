using System;
using CheckoutPaymentGateway.Enums;
using CheckoutPaymentGateway.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CheckoutPaymentGateway.Models
{
    public class PaymentResponse : IPaymentResponse
    {
        public Guid Id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }
    }
}