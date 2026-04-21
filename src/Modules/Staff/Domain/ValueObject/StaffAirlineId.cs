namespace GestionAerolineas.src.Modules.Staff.Domain.ValueObject
{
    public sealed record StaffAirlineId
    {
        public int? Value { get; }

        private StaffAirlineId(int? value)
        {
            Value = value;
        }

        public static StaffAirlineId Create(int? value)
        {
            if (!value.HasValue)
                return new StaffAirlineId((int?)null);

            if (value.Value <= 0)
                throw new ArgumentException("El aerolinea_id no puede ser menor a 1");

            return new StaffAirlineId(value.Value);
        }
    }
}

