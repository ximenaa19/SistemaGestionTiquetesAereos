namespace GestionAerolineas.src.Modules.AirportAirline.Domain.ValueObject
{
    public sealed record AirportAirlineAirportId
    {
        public int Value { get; }

        private AirportAirlineAirportId(int value)
        {
            Value = value;
        }

        public static AirportAirlineAirportId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El valor no puede ser menor a 1");

            return new AirportAirlineAirportId(value);
        }
    }
}

