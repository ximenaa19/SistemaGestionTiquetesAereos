namespace GestionAerolineas.src.Modules.AirportAirline.Domain.ValueObject
{
    public sealed record AirportAirlineAirlineId
    {
        public int Value { get; }

        private AirportAirlineAirlineId(int value)
        {
            Value = value;
        }

        public static AirportAirlineAirlineId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El valor no puede ser menor a 1");

            return new AirportAirlineAirlineId(value);
        }
    }
}

