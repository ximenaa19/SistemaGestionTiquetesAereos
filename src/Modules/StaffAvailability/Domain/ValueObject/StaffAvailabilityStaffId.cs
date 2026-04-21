namespace GestionAerolineas.src.Modules.StaffAvailability.Domain.ValueObject
{
    public sealed record StaffAvailabilityStaffId
    {
        public int Value { get; }

        private StaffAvailabilityStaffId(int value)
        {
            Value = value;
        }

        public static StaffAvailabilityStaffId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El personal_id no puede ser menor a 1");

            return new StaffAvailabilityStaffId(value);
        }
    }
}

