using System;
using System.Collections.Generic;
using CheckoutPaymentGateway.Interfaces;

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
        public void SaveObject(Guid id, object objectToSave)
        {
            if (_storageObject.ContainsKey(id))
            {
                _storageObject[id] = objectToSave;
            }
            else
            {
                _storageObject.Add(id, objectToSave);
            }
        }

        /// <inheritdoc />
        public object GetObject(Guid id)
        {
            if (!_storageObject.ContainsKey(id))
            {
                return null;
            }

            return _storageObject[id];
        }
    }
}