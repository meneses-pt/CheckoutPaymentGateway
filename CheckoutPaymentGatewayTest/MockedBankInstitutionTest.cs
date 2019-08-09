using System;
using CheckoutPaymentGateway.Mock;
using CheckoutPaymentGateway.Models.Enums;
using CheckoutPaymentGateway.Models.Models;
using Xunit;

namespace CheckoutPaymentGatewayTest
{
    public class MockedBankInstitutionTest
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

            var mockedBankInstitution = new MockedBankInstitution();
            var response = mockedBankInstitution.ProcessPayment(paymentRequest);

            Assert.IsType<Guid>(response.Id);
            Assert.Equal(Status.Authorized, response.Status);
        }

        /// <summary>
        /// Tests Processing a payment with negative amount
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

            var mockedBankInstitution = new MockedBankInstitution();
            var response = mockedBankInstitution.ProcessPayment(paymentRequest);

            Assert.IsType<Guid>(response.Id);
            Assert.Equal(Status.Declined, response.Status);
        }

        /// <summary>
        /// Tests processing a payment with no Card Number
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

            var mockedBankInstitution = new MockedBankInstitution();
            var response = mockedBankInstitution.ProcessPayment(paymentRequest);

            Assert.IsType<Guid>(response.Id);
            Assert.Equal(Status.Declined, response.Status);
        }

        /// <summary>
        /// Tests processing a payment with an expired card
        /// </summary>
        [Fact]
        public void ProcessInvalidPayment3()
        {
            var paymentRequest = new PaymentRequest
            {
                CardNumber = "1234123412341234",
                CardHolderName = "JOHN DOE",
                ExpiryDate = "10/18",
                Amount = 123.12,
                Currency = "GBP",
                CVV = "123"
            };

            var mockedBankInstitution = new MockedBankInstitution();
            var response = mockedBankInstitution.ProcessPayment(paymentRequest);

            Assert.IsType<Guid>(response.Id);
            Assert.Equal(Status.Expired, response.Status);
        }

        /// <summary>
        /// Tests processing a null payment
        /// </summary>
        [Fact]
        public void ProcessInvalidPayment4()
        {
            var mockedBankInstitution = new MockedBankInstitution();
            var response = mockedBankInstitution.ProcessPayment(null);

            Assert.Null(response);
        }
    }
}