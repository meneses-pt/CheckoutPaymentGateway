using System;
using CheckoutPaymentGateway.Enums;

namespace CheckoutPaymentGateway.Interfaces
{
    public interface IPaymentResponse
    {
        Guid Id { get; set; }

        Status Status { get; set; }
    }
}