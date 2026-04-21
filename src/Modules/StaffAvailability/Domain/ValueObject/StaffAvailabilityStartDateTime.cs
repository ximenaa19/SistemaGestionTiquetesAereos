namespace GestionAerolineas.src.Modules.StaffAvailability.Domain.ValueObject
{
    public sealed record StaffAvailabilityStartDateTime
    {
        public DateTime Value { get; }

        private StaffAvailabilityStartDateTime(DateTime value)
        {
            Value = value;
        }

        public static StaffAvailabilityStartDateTime Create(DateTime value)
        {
            if (value == default)
                throw new ArgumentException("La fecha_inicio es invalida");

            return new StaffAvailabilityStartDateTime(value);
        }
    }
}

