namespace CheckoutPaymentGateway.Interfaces
{
    /// <summary>
    /// The Payment Request Structure Interface
    /// </summary>
    public interface IPaymentRequest
    {
        /// <summary>
        /// Gets or sets the credit card number.
        /// </summary>
        /// <value>
        /// The credit card number.
        /// </value>
        string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the credit card holder.
        /// </summary>
        /// <value>
        /// The name of the credit card holder.
        /// </value>
        string CardHolderName { get; set; }

        /// <summary>
        /// Gets or sets the expiry date for the credit card.
        /// </summary>
        /// <value>
        /// The expiry date of the credit card.
        /// </value>
        string ExpiryDate { get; set; }

        /// <summary>
        /// Gets or sets the amount to be charged on the payment.
        /// </summary>
        /// <value>
        /// The amount to be charged on the payment.
        /// </value>
        double Amount { get; set; }

        /// <summary>
        /// Gets or sets the currency for the payment.
        /// </summary>
        /// <value>
        /// The currency for the payment.
        /// </value>
        string Currency { get; set; }

        /// <summary>
        /// Gets or sets the CVV code of the credit card.
        /// </summary>
        /// <value>
        /// The CVV code of the credit card.
        /// </value>
        string CVV { get; set; }

        /// <summary>
        /// Masks the credit card number.
        /// </summary>
        string MaskCardNumber();
    }
}