namespace GestionAerolineas.src.Modules.StaffAvailability.Domain.ValueObject
{
    public sealed record StaffAvailabilityEndDateTime
    {
        public DateTime Value { get; }

        private StaffAvailabilityEndDateTime(DateTime value)
        {
            Value = value;
        }

        public static StaffAvailabilityEndDateTime Create(DateTime value)
        {
            if (value == default)
                throw new ArgumentException("La fecha_fin es invalida");

            return new StaffAvailabilityEndDateTime(value);
        }
    }
}

