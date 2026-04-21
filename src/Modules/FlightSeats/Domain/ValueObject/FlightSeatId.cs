namespace GestionAerolineas.src.Modules.FlightSeats.Domain.ValueObject
{
    public sealed record FlightSeatId
    {
        public int Value { get; }

        private FlightSeatId(int value)
        {
            Value = value;
        }

        public static FlightSeatId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El id no puede ser menor a 1");

            return new FlightSeatId(value);
        }

        public static FlightSeatId CreateEmpty()
        {
            return new FlightSeatId(0);
        }
    }
}

