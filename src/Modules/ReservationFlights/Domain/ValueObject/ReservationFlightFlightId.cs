namespace GestionAerolineas.src.Modules.ReservationFlights.Domain.ValueObject
{
    public sealed record ReservationFlightFlightId
    {
        public int Value { get; }

        private ReservationFlightFlightId(int value)
        {
            Value = value;
        }

        public static ReservationFlightFlightId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El vuelo_id no puede ser menor a 1");

            return new ReservationFlightFlightId(value);
        }
    }
}

