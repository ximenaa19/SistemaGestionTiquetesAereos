namespace GestionAerolineas.src.Modules.ReservationFlights.Domain.ValueObject
{
    public sealed record ReservationFlightPartialAmount
    {
        public decimal Value { get; }

        private ReservationFlightPartialAmount(decimal value)
        {
            Value = value;
        }

        public static ReservationFlightPartialAmount Create(decimal value)
        {
            if (value < 0)
                throw new ArgumentException("El valor_parcial no puede ser negativo");

            return new ReservationFlightPartialAmount(value);
        }
    }
}

