using System.Runtime.Serialization;

namespace CheckoutPaymentGateway.Enums
{
    public enum Status
    {
        [EnumMember(Value = "Authorized")]
        Authorized,
        [EnumMember(Value = "Declined")]
        Declined
    }
}