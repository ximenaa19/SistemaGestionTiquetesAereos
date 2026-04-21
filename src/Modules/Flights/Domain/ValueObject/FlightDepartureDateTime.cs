namespace GestionAerolineas.src.Modules.Flights.Domain.ValueObject
{
    public sealed record FlightDepartureDateTime
    {
        public DateTime Value { get; }

        private FlightDepartureDateTime(DateTime value)
        {
            Value = value;
        }

        public static FlightDepartureDateTime Create(DateTime value)
        {
            if (value == default)
                throw new ArgumentException("La fecha_salida es invalida");

            return new FlightDepartureDateTime(value);
        }
    }
}

