namespace GestionAerolineas.src.Modules.Flights.Domain.ValueObject
{
    public sealed record FlightRescheduledAt
    {
        public DateTime? Value { get; }

        private FlightRescheduledAt(DateTime? value)
        {
            Value = value;
        }

        public static FlightRescheduledAt Create(DateTime? value)
        {
            return new FlightRescheduledAt(value);
        }
    }
}

