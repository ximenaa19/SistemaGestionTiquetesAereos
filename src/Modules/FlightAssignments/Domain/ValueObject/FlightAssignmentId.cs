namespace GestionAerolineas.src.Modules.FlightAssignments.Domain.ValueObject
{
    public sealed record FlightAssignmentId
    {
        public int Value { get; }

        private FlightAssignmentId(int value)
        {
            Value = value;
        }

        public static FlightAssignmentId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El id no puede ser menor a 1");

            return new FlightAssignmentId(value);
        }

        public static FlightAssignmentId CreateEmpty()
        {
            return new FlightAssignmentId(0);
        }
    }
}

