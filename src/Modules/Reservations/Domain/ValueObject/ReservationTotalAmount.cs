namespace GestionAerolineas.src.Modules.Reservations.Domain.ValueObject
{
    public sealed record ReservationTotalAmount
    {
        public decimal Value { get; }

        private ReservationTotalAmount(decimal value)
        {
            Value = value;
        }

        public static ReservationTotalAmount Create(decimal value)
        {
            if (value < 0)
                throw new ArgumentException("El valor_total no puede ser negativo");

            return new ReservationTotalAmount(value);
        }
    }
}

