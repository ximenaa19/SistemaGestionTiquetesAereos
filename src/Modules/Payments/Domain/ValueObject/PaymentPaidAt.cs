namespace GestionAerolineas.src.Modules.Payments.Domain.ValueObject
{
    public sealed record PaymentPaidAt
    {
        public DateTime Value { get; }

        private PaymentPaidAt(DateTime value)
        {
            Value = value;
        }

        public static PaymentPaidAt Create(DateTime value)
        {
            return new PaymentPaidAt(value);
        }
    }
}

