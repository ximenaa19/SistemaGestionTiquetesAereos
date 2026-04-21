namespace GestionAerolineas.src.Modules.FlightSeats.Domain.ValueObject
{
    public sealed record FlightSeatIsOccupied
    {
        public bool Value { get; }

        private FlightSeatIsOccupied(bool value)
        {
            Value = value;
        }

        public static FlightSeatIsOccupied Create(bool value)
        {
            return new FlightSeatIsOccupied(value);
        }
    }
}

