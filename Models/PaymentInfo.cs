using CheckoutPaymentGateway.Interfaces;

namespace CheckoutPaymentGateway.Models
{
    /// <summary>
    /// An Entity containing the Payment Request and Payment Response Information
    /// </summary>
    public class PaymentInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentInfo"/> class.
        /// </summary>
        /// <param name="request">The payment request.</param>
        /// <param name="response">The payment response.</param>
        public PaymentInfo(IPaymentRequest request, IPaymentResponse response)
        {
            Request = request;
            Response = response;
        }

        /// <summary>
        /// Gets or sets the payment request.
        /// </summary>
        /// <value>
        /// The payment request.
        /// </value>
        public IPaymentRequest Request { get; set; }

        /// <summary>
        /// Gets or sets the payment response.
        /// </summary>
        /// <value>
        /// The payment response.
        /// </value>
        public IPaymentResponse Response { get; set; }
    }
}