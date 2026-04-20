namespace GestionAerolineas.src.Modules.AirportAirline.Domain.ValueObject
{
    public sealed record AirportAirlineIsActive
    {
        public bool Value { get; }

        private AirportAirlineIsActive(bool value)
        {
            Value = value;
        }

        public static AirportAirlineIsActive Create(bool value)
        {
            return new AirportAirlineIsActive(value);
        }
    }
}

