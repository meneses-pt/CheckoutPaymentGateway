using CheckoutPaymentGateway.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckoutPaymentGateway.DataStorage
{
    /// <summary>
    /// The Payment Gateway Context for the database using EntityFramework
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class PaymentGatewayContext : DbContext
    {
        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>
        /// The connection string.
        /// </value>
        private string ConnectionString { get; }

        /// <summary>
        /// Gets or sets the payments information DBSet.
        /// </summary>
        /// <value>
        /// The payments information DBSet.
        /// </value>
        public DbSet<PaymentInfo> PaymentsInfo { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentGatewayContext"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string for the databse.</param>
        public PaymentGatewayContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentInfo>().OwnsOne(p => p.Request, r =>
            {
                r.Property(e => e.CardNumber).HasColumnName("CardNumber");
                r.Property(e => e.CardHolderName).HasColumnName("CardHolderName");
                r.Property(e => e.ExpiryDate).HasColumnName("ExpiryDate");
                r.Property(e => e.Amount).HasColumnName("Amount");
                r.Property(e => e.Currency).HasColumnName("Currency");
                r.Property(e => e.CVV).HasColumnName("CVV");
            });
            modelBuilder.Entity<PaymentInfo>().OwnsOne(p => p.Response, r =>
            {
                r.Property(e => e.Id).HasColumnName("Id");
                r.Property(e => e.Status).HasColumnName("Status");
            });
            modelBuilder.Entity<PaymentInfo>().HasKey(p => p.Id);
        }
    }
}
