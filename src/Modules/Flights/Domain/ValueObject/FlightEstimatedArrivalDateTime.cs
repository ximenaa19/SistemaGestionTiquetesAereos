namespace GestionAerolineas.src.Modules.Flights.Domain.ValueObject
{
    public sealed record FlightEstimatedArrivalDateTime
    {
        public DateTime Value { get; }

        private FlightEstimatedArrivalDateTime(DateTime value)
        {
            Value = value;
        }

        public static FlightEstimatedArrivalDateTime Create(DateTime value)
        {
            if (value == default)
                throw new ArgumentException("La fecha_llegada_estimada es invalida");

            return new FlightEstimatedArrivalDateTime(value);
        }
    }
}

