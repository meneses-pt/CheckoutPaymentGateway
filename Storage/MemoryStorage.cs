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
        public Dictionary<Guid, object> StorageObject = new Dictionary<Guid, object>();

        /// <inheritdoc />
        public void SaveObject(Guid id, object objectToSave)
        {
            if (StorageObject.ContainsKey(id))
            {
                StorageObject[id] = objectToSave;
            }
            else
            {
                StorageObject.Add(id, objectToSave);
            }
        }

        /// <inheritdoc />
        public object GetObject(Guid id)
        {
            if (!StorageObject.ContainsKey(id))
            {
                return null;
            }

            return StorageObject[id];
        }
    }
}