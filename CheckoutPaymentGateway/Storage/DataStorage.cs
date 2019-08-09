using System;
using System.Linq;
using CheckoutPaymentGateway.DataStorage;
using CheckoutPaymentGateway.Interfaces;
using CheckoutPaymentGateway.Models.Models;

namespace CheckoutPaymentGateway.Storage
{
    /// <summary>
    /// Storage Implementation to Access a Database storage
    /// </summary>
    /// <seealso cref="CheckoutPaymentGateway.Interfaces.IStorage" />
    public class DataStorage : IStorage
    {
        /// <summary>
        /// Gets the connection string for the database.
        /// </summary>
        /// <value>
        /// The connection string for the database.
        /// </value>
        private string ConnectionString { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataStorage"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string for the database.</param>
        public DataStorage(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <inheritdoc />
        public void SavePaymentInfo(PaymentInfo objectToSave)
        {
            using (var context = new PaymentGatewayContext(ConnectionString))
            {
                context.PaymentsInfo.Add(objectToSave);
                context.SaveChanges();
            }
        }

        /// <inheritdoc />
        public PaymentInfo GetPaymentInfo(Guid id)
        {
            using (var context = new PaymentGatewayContext(ConnectionString))
            {
                return context.PaymentsInfo.FirstOrDefault(pi => pi.Response.Id == id);
            }
        }
    }
}
