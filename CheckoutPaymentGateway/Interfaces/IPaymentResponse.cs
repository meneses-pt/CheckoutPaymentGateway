using System;
using CheckoutPaymentGateway.Enums;

namespace CheckoutPaymentGateway.Interfaces
{
    /// <summary>
    /// The Payment Response Structure Interface
    /// </summary>
    public interface IPaymentResponse
    {
        /// <summary>
        /// Gets or sets the Payment identifier.
        /// </summary>
        /// <value>
        /// The Payment identifier.
        /// </value>
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Payment status.
        /// </summary>
        /// <value>
        /// The Payment status.
        /// </value>
        Status Status { get; set; }
    }
}