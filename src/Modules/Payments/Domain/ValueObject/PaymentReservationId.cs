namespace GestionAerolineas.src.Modules.Payments.Domain.ValueObject
{
    public sealed record PaymentReservationId
    {
        public int Value { get; }

        private PaymentReservationId(int value)
        {
            Value = value;
        }

        public static PaymentReservationId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El reserva_id no puede ser menor a 1");

            return new PaymentReservationId(value);
        }
    }
}

