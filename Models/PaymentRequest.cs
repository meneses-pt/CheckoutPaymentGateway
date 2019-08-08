using System.Text.RegularExpressions;
using CheckoutPaymentGateway.Interfaces;

namespace CheckoutPaymentGateway.Models
{
    public class PaymentRequest : IPaymentRequest
    {
        public string CardNumber { get; set; }

        public string CardHolderName { get; set; }

        public string ExpiryDate { get; set; }

        public double Amount { get; set; }

        public string Currency { get; set; }

        public string CVV { get; set; }

        public void MaskCardNumber()
        {
            CardNumber = Regex.Replace(CardNumber.Substring(0, CardNumber.Length - 4), "\\d", "*") + CardNumber.Substring(CardNumber.Length - 4, 4);
        }
    }
}