namespace GestionAerolineas.src.Modules.Aircraft.Domain.ValueObject
{
    public sealed record AircraftManufactureDate
    {
        public DateTime? Value { get; }

        private AircraftManufactureDate(DateTime? value)
        {
            Value = value;
        }

        public static AircraftManufactureDate Create(DateTime? value)
        {
            if (value.HasValue && value.Value.Date > DateTime.UtcNow.Date)
                throw new ArgumentException("La fecha de fabricacion no puede ser futura");

            return new AircraftManufactureDate(value?.Date);
        }
    }
}

