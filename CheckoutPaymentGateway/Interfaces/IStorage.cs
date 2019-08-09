using System;
using CheckoutPaymentGateway.Models.Models;

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
        /// <param name="objectToSave">The object to save.</param>
        void SavePaymentInfo(PaymentInfo objectToSave);

        /// <summary>
        /// Gets the saved object.
        /// </summary>
        /// <param name="id">The Payment Info identifier.</param>
        /// <returns>The saved object</returns>
        PaymentInfo GetPaymentInfo(Guid id);
    }
}