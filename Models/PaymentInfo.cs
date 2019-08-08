using CheckoutPaymentGateway.Interfaces;

namespace CheckoutPaymentGateway.Models
{
    public class PaymentInfo
    {
        public PaymentInfo(IPaymentRequest request, IPaymentResponse response)
        {
            Request = request;
            Response = response;
        }

        public IPaymentRequest Request { get; set; }

        public IPaymentResponse Response { get; set; }
    }
}