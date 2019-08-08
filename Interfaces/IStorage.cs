using System;

namespace CheckoutPaymentGateway.Interfaces
{
    public interface IStorage
    {
        void SaveObject(Guid id, object objectToSave);

        object GetObject(Guid id);
    }
}