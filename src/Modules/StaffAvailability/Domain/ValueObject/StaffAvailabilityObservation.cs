namespace GestionAerolineas.src.Modules.StaffAvailability.Domain.ValueObject
{
    public sealed record StaffAvailabilityObservation
    {
        public string? Value { get; }

        private StaffAvailabilityObservation(string? value)
        {
            Value = value;
        }

        public static StaffAvailabilityObservation Create(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return new StaffAvailabilityObservation((string?)null);

            var trimmed = value.Trim();
            if (trimmed.Length > 255)
                throw new ArgumentException("La observacion no puede tener mas de 255 caracteres");

            return new StaffAvailabilityObservation(trimmed);
        }
    }
}
