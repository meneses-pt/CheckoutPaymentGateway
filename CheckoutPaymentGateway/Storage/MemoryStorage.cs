using System;
using System.Collections.Generic;
using CheckoutPaymentGateway.Interfaces;
using CheckoutPaymentGateway.Models.Models;

namespace CheckoutPaymentGateway.Storage
{
    /// <summary>
    /// A Memory Storage Implementation
    /// </summary>
    /// <seealso cref="CheckoutPaymentGateway.Interfaces.IStorage" />
    public class MemoryStorage : IStorage
    {
        /// <summary>
        /// The storage object that will hold the information
        /// </summary>
        private readonly Dictionary<Guid, object> _storageObject = new Dictionary<Guid, object>();

        /// <inheritdoc />
        public void SavePaymentInfo(PaymentInfo objectToSave)
        {
            if (_storageObject.ContainsKey(objectToSave.Response.Id))
            {
                _storageObject[objectToSave.Response.Id] = objectToSave;
            }
            else
            {
                _storageObject.Add(objectToSave.Response.Id, objectToSave);
            }
        }

        /// <inheritdoc />
        public PaymentInfo GetPaymentInfo(Guid id)
        {
            if (!_storageObject.ContainsKey(id))
            {
                return null;
            }

            return _storageObject[id] as PaymentInfo;
        }
    }
}