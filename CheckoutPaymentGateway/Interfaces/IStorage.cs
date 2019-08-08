using System;

namespace CheckoutPaymentGateway.Interfaces
{
    /// <summary>
    /// The Interface to Access a Storage
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Saves an object.
        /// </summary>
        /// <param name="id">The object identifier.</param>
        /// <param name="objectToSave">The object to save.</param>
        void SaveObject(Guid id, object objectToSave);

        /// <summary>
        /// Gets the saved object.
        /// </summary>
        /// <param name="id">The object identifier.</param>
        /// <returns>The saved object</returns>
        object GetObject(Guid id);
    }
}