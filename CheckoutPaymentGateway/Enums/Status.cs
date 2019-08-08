using System.Runtime.Serialization;

namespace CheckoutPaymentGateway.Enums
{
    /// <summary>
    /// Status enum for the Payment Responses
    /// </summary>
    public enum Status
    {
        [EnumMember(Value = "Authorized")]
        Authorized,
        [EnumMember(Value = "Declined")]
        Declined,
        [EnumMember(Value = "Expired")]
        Expired
    }
}