using System;
using CheckoutPaymentGateway.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CheckoutPaymentGateway.Models.Models
{
    /// <summary>
    /// An implementation of the Payment Response structure
    /// </summary>
    [Owned]
    public class PaymentResponse
    {
        /// <summary>
        /// Gets or sets the Payment identifier.
        /// </summary>
        /// <value>
        /// The Payment identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Payment status.
        /// </summary>
        /// <value>
        /// The Payment status.
        /// </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }
    }
}