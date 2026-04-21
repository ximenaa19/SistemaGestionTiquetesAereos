namespace GestionAerolineas.src.Modules.Staff.Domain.ValueObject
{
    public sealed record StaffAirportId
    {
        public int? Value { get; }

        private StaffAirportId(int? value)
        {
            Value = value;
        }

        public static StaffAirportId Create(int? value)
        {
            if (!value.HasValue)
                return new StaffAirportId((int?)null);

            if (value.Value <= 0)
                throw new ArgumentException("El aeropuerto_id no puede ser menor a 1");

            return new StaffAirportId(value.Value);
        }
    }
}

