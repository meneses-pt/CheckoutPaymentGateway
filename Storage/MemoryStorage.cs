using System;
using System.Collections.Generic;
using CheckoutPaymentGateway.Interfaces;

namespace CheckoutPaymentGateway.Storage
{
    public class MemoryStorage : IStorage
    {
        public Dictionary<Guid, object> StorageObject = new Dictionary<Guid, object>();

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