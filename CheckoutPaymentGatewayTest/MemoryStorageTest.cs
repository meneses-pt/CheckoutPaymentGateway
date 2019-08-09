using System;
using CheckoutPaymentGateway.Models.Enums;
using CheckoutPaymentGateway.Models.Models;
using CheckoutPaymentGateway.Storage;
using Xunit;

namespace CheckoutPaymentGatewayTest
{
    public class MemoryStorageTest
    {
        /// <summary>
        /// Tests saving an object to the storage and checking the returned one is the same
        /// </summary>
        [Fact]
        public void SaveAndReturn()
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

            var paymentResponse = new PaymentResponse
            {
                Id = Guid.NewGuid(),
                Status = Status.Authorized
            };

            var paymentInfo = new PaymentInfo(paymentRequest, paymentResponse);

            var memoryStorage = new MemoryStorage();

            memoryStorage.SavePaymentInfo(paymentInfo);
            var returnedObject = memoryStorage.GetPaymentInfo(paymentResponse.Id);

            Assert.Equal(paymentRequest.CardHolderName, returnedObject.Request.CardHolderName);

            var nullObject = memoryStorage.GetPaymentInfo(Guid.NewGuid());

            Assert.Null(nullObject);
        }
    }
}