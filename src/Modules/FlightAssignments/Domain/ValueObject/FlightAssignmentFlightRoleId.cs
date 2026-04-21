namespace GestionAerolineas.src.Modules.FlightAssignments.Domain.ValueObject
{
    public sealed record FlightAssignmentFlightRoleId
    {
        public int Value { get; }

        private FlightAssignmentFlightRoleId(int value)
        {
            Value = value;
        }

        public static FlightAssignmentFlightRoleId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El rol_vuelo_id no puede ser menor a 1");

            return new FlightAssignmentFlightRoleId(value);
        }
    }
}

