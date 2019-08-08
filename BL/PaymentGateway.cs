using System;
using CheckoutPaymentGateway.Interfaces;
using CheckoutPaymentGateway.Models;
using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account.Manage;

namespace CheckoutPaymentGateway.BL
{
    public class PaymentGateway : IPaymentGateway
    {
        private readonly IBank _bank;
        private readonly IStorage _storage;

        public PaymentGateway(IBank bank, IStorage storage)
        {
            _bank = bank;
            _storage = storage;
        }

        public IPaymentResponse ProcessPayment(PaymentRequest request)
        {
            var bankResponse = _bank.ProcessPayment(request);
            var paymentInfo = new PaymentInfo(request, bankResponse);
            _storage.SaveObject(paymentInfo.Response.Id, paymentInfo);
            return bankResponse;
        }

        public PaymentInfo RetrievePayamentInfo(Guid id)
        {
            var paymentInfo = _storage.GetObject(id) as PaymentInfo;
            paymentInfo?.Request.MaskCardNumber();

            return paymentInfo;
        }
    }
}