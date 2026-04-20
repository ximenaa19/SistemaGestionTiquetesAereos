namespace GestionAerolineas.src.Modules.AirportAirline.Domain.ValueObject
{
    public sealed record AirportAirlineStartDate
    {
        public DateTime Value { get; }

        private AirportAirlineStartDate(DateTime value)
        {
            Value = value.Date;
        }

        public static AirportAirlineStartDate Create(DateTime value)
        {
            if (value == default)
                throw new ArgumentException("La fecha_inicio es requerida");

            return new AirportAirlineStartDate(value);
        }
    }
}

