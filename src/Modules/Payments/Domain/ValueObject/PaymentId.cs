namespace GestionAerolineas.src.Modules.Payments.Domain.ValueObject
{
    public sealed record PaymentId
    {
        public int Value { get; }

        private PaymentId(int value)
        {
            Value = value;
        }

        public static PaymentId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El id no puede ser menor a 1");

            return new PaymentId(value);
        }

        public static PaymentId CreateEmpty()
        {
            return new PaymentId(0);
        }
    }
}

