namespace GestionAerolineas.src.Modules.FlightAssignments.Domain.ValueObject
{
    public sealed record FlightAssignmentFlightId
    {
        public int Value { get; }

        private FlightAssignmentFlightId(int value)
        {
            Value = value;
        }

        public static FlightAssignmentFlightId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El vuelo_id no puede ser menor a 1");

            return new FlightAssignmentFlightId(value);
        }
    }
}

