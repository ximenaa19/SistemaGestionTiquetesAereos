namespace GestionAerolineas.src.Modules.Flights.Domain.ValueObject
{
    public sealed record FlightTotalCapacity
    {
        public int Value { get; }

        private FlightTotalCapacity(int value)
        {
            Value = value;
        }

        public static FlightTotalCapacity Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("La capacidad_total debe ser mayor a 0");

            return new FlightTotalCapacity(value);
        }
    }
}

