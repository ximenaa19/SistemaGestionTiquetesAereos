namespace GestionAerolineas.src.Modules.ReservationFlights.Domain.ValueObject
{
    public sealed record ReservationFlightId
    {
        public int Value { get; }

        private ReservationFlightId(int value)
        {
            Value = value;
        }

        public static ReservationFlightId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El id no puede ser menor a 1");

            return new ReservationFlightId(value);
        }

        public static ReservationFlightId CreateEmpty()
        {
            return new ReservationFlightId(0);
        }
    }
}

