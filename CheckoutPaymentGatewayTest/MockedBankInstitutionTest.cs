using System;
using CheckoutPaymentGateway.Enums;
using CheckoutPaymentGateway.Mock;
using CheckoutPaymentGateway.Models;
using CheckoutPaymentGateway.Storage;
using Xunit;

namespace CheckoutPaymentGatewayTest
{
    public class MockedBankInstitutionTest
    {
        [Fact]
        public void ProcessValidPayment()
        {
            var paymentRequest = new PaymentRequest
            {
                CardNumber = "1234123412341234",
                CardHolderName = "JOHN DOE",
                ExpiryDate = "10/20",
                Amount = 123.12,
                Currency = "GBP",
                CVV = "123"
            };

            var mockedBankInstitution = new MockedBankInstitution();
            var response = mockedBankInstitution.ProcessPayment(paymentRequest);

            Assert.IsType<Guid>(response.Id);
            Assert.Equal(Status.Authorized, response.Status);
        }

        [Fact]
        public void ProcessInvalidPayment1()
        {
            var paymentRequest = new PaymentRequest
            {
                CardNumber = "1234123412341234",
                CardHolderName = "JOHN DOE",
                ExpiryDate = "10/20",
                Amount = -1,
                Currency = "GBP",
                CVV = "123"
            };

            var mockedBankInstitution = new MockedBankInstitution();
            var response = mockedBankInstitution.ProcessPayment(paymentRequest);

            Assert.IsType<Guid>(response.Id);
            Assert.Equal(Status.Declined, response.Status);
        }

        [Fact]
        public void ProcessInvalidPayment2()
        {
            var paymentRequest = new PaymentRequest
            {
                CardNumber = "",
                CardHolderName = "JOHN DOE",
                ExpiryDate = "10/20",
                Amount = 123.12,
                Currency = "GBP",
                CVV = "123"
            };

            var mockedBankInstitution = new MockedBankInstitution();
            var response = mockedBankInstitution.ProcessPayment(paymentRequest);

            Assert.IsType<Guid>(response.Id);
            Assert.Equal(Status.Declined, response.Status);
        }

        [Fact]
        public void ProcessInvalidPayment3()
        {
            var mockedBankInstitution = new MockedBankInstitution();
            var response = mockedBankInstitution.ProcessPayment(null);

            Assert.Null(response);
        }
    }
}
