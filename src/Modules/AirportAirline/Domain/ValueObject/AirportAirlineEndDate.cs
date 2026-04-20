namespace GestionAerolineas.src.Modules.AirportAirline.Domain.ValueObject
{
    public sealed record AirportAirlineEndDate
    {
        public DateTime? Value { get; }

        private AirportAirlineEndDate(DateTime? value)
        {
            Value = value?.Date;
        }

        public static AirportAirlineEndDate Create(DateTime? value)
        {
            return new AirportAirlineEndDate(value);
        }
    }
}

