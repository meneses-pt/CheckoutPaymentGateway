using System;

namespace CheckoutPaymentGateway.Models.Models
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
        public PaymentInfo(PaymentRequest request, PaymentResponse response)
        {
            Request = request;
            Response = response;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentInfo"/> class.
        /// This is needed to be explicitly set for Entity Framework
        /// </summary>
        public PaymentInfo()
        {
        }

        /// <summary>
        /// Gets or sets the identifier (for Entity Framework).
        /// </summary>
        /// <value>
        /// The identifier for Entity Framework.
        /// </value>
        public Guid Id
        {
            get => Response.Id;
            set
            {
                if (Response == null)
                {
                    Response = new PaymentResponse();
                }

                Response.Id = value;
            }
        }

        /// <summary>
        /// Gets or sets the payment request.
        /// </summary>
        /// <value>
        /// The payment request.
        /// </value>
        public PaymentRequest Request { get; set; }

        /// <summary>
        /// Gets or sets the payment response.
        /// </summary>
        /// <value>
        /// The payment response.
        /// </value>
        public PaymentResponse Response { get; set; }
    }
}