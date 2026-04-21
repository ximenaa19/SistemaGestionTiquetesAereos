namespace GestionAerolineas.src.Modules.FlightAssignments.Domain.ValueObject
{
    public sealed record FlightAssignmentStaffId
    {
        public int Value { get; }

        private FlightAssignmentStaffId(int value)
        {
            Value = value;
        }

        public static FlightAssignmentStaffId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El personal_id no puede ser menor a 1");

            return new FlightAssignmentStaffId(value);
        }
    }
}

