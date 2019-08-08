using System;
using CheckoutPaymentGateway.BL;
using CheckoutPaymentGateway.Enums;
using CheckoutPaymentGateway.Mock;
using CheckoutPaymentGateway.Models;
using CheckoutPaymentGateway.Storage;
using Xunit;

namespace CheckoutPaymentGatewayTest
{
    public class PaymentGatewayTest
    {
        /// <summary>
        /// Tests processing a valid payment
        /// </summary>
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

            var paymentGateway = new PaymentGateway(new MockedBankInstitution(), new MemoryStorage());
            var response = paymentGateway.ProcessPayment(paymentRequest);
            Assert.IsType<Guid>(response.Id);
            Assert.Equal(Status.Authorized, response.Status);


            var savedResponse = paymentGateway.RetrievePaymentInfo(response.Id);
            Assert.Equal(response.GetHashCode(), savedResponse.Response.GetHashCode());
            Assert.Equal(paymentRequest.Amount, savedResponse.Request.Amount);
            Assert.Equal(paymentRequest.MaskCardNumber(), savedResponse.Request.CardNumber);
        }

        /// <summary>
        /// Tests processing payment with negative amount
        /// </summary>
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

            var paymentGateway = new PaymentGateway(new MockedBankInstitution(), new MemoryStorage());
            var response = paymentGateway.ProcessPayment(paymentRequest);
            Assert.IsType<Guid>(response.Id);
            Assert.Equal(Status.Declined, response.Status);


            var savedResponse = paymentGateway.RetrievePaymentInfo(response.Id);
            Assert.Equal(response, savedResponse.Response);
            Assert.Equal(paymentRequest, savedResponse.Request);
        }

        /// <summary>
        /// Tests processing payment with no card number
        /// </summary>
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

            var paymentGateway = new PaymentGateway(new MockedBankInstitution(), new MemoryStorage());
            var response = paymentGateway.ProcessPayment(paymentRequest);
            Assert.IsType<Guid>(response.Id);
            Assert.Equal(Status.Declined, response.Status);


            var savedResponse = paymentGateway.RetrievePaymentInfo(response.Id);
            Assert.Equal(response, savedResponse.Response);
            Assert.Equal(paymentRequest, savedResponse.Request);
        }

        /// <summary>
        /// Tests processing null payment
        /// </summary>
        [Fact]
        public void ProcessInvalidPayment3()
        {
            var paymentGateway = new PaymentGateway(new MockedBankInstitution(), new MemoryStorage());
            var response = paymentGateway.ProcessPayment(null);

            Assert.Null(response);
        }
    }
}
