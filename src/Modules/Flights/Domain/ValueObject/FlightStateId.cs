namespace GestionAerolineas.src.Modules.Flights.Domain.ValueObject
{
    public sealed record FlightStateId
    {
        public int Value { get; }

        private FlightStateId(int value)
        {
            Value = value;
        }

        public static FlightStateId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El estado_vuelo_id no puede ser menor a 1");

            return new FlightStateId(value);
        }
    }
}

