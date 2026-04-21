namespace GestionAerolineas.src.Modules.Flights.Domain.ValueObject
{
    public sealed record FlightAvailableSeats
    {
        public int Value { get; }

        private FlightAvailableSeats(int value)
        {
            Value = value;
        }

        public static FlightAvailableSeats Create(int value)
        {
            if (value < 0)
                throw new ArgumentException("Los asientos_disponibles no pueden ser negativos");

            return new FlightAvailableSeats(value);
        }
    }
}

