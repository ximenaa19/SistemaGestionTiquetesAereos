namespace GestionAerolineas.src.Modules.Payments.Domain.ValueObject
{
    public sealed record PaymentAmount
    {
        public decimal Value { get; }

        private PaymentAmount(decimal value)
        {
            Value = value;
        }

        public static PaymentAmount Create(decimal value)
        {
            if (value < 0)
                throw new ArgumentException("El monto no puede ser negativo");

            return new PaymentAmount(value);
        }
    }
}

