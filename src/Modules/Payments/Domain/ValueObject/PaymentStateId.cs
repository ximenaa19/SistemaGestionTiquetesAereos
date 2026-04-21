namespace GestionAerolineas.src.Modules.Payments.Domain.ValueObject
{
    public sealed record PaymentStateId
    {
        public int Value { get; }

        private PaymentStateId(int value)
        {
            Value = value;
        }

        public static PaymentStateId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El estado_pago_id no puede ser menor a 1");

            return new PaymentStateId(value);
        }
    }
}

