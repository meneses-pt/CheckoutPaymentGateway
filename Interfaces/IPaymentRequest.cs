namespace CheckoutPaymentGateway.Interfaces
{
    public interface IPaymentRequest
    {
        string CardNumber { get; set; }

        string CardHolderName { get; set; }

        string ExpiryDate { get; set; }

        double Amount { get; set; }

        string Currency { get; set; }

        string CVV { get; set; }

        void MaskCardNumber();
    }
}