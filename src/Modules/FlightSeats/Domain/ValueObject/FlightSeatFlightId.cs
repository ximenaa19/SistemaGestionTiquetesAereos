namespace GestionAerolineas.src.Modules.FlightSeats.Domain.ValueObject
{
    public sealed record FlightSeatFlightId
    {
        public int Value { get; }

        private FlightSeatFlightId(int value)
        {
            Value = value;
        }

        public static FlightSeatFlightId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El vuelo_id no puede ser menor a 1");

            return new FlightSeatFlightId(value);
        }
    }
}

