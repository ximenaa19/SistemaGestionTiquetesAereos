namespace GestionAerolineas.src.Modules.Flights.Domain.ValueObject
{
    public sealed record FlightId
    {
        public int Value { get; }

        private FlightId(int value)
        {
            Value = value;
        }

        public static FlightId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El id no puede ser menor a 1");

            return new FlightId(value);
        }

        public static FlightId CreateEmpty()
        {
            return new FlightId(0);
        }
    }
}

