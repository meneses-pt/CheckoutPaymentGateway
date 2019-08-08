using System;
using CheckoutPaymentGateway.Models;
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

            var memoryStorage = new MemoryStorage();
            var id = Guid.NewGuid();

            memoryStorage.SaveObject(id, paymentRequest);
            var returnedObject = memoryStorage.GetObject(id);

            Assert.Equal(paymentRequest.CardHolderName, ((PaymentRequest)returnedObject).CardHolderName);

            var nullObject = memoryStorage.GetObject(Guid.NewGuid());
            
            Assert.Null(nullObject);

        }
    }
}
