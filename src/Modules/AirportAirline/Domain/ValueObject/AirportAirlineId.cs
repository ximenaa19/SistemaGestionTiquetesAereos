namespace GestionAerolineas.src.Modules.AirportAirline.Domain.ValueObject
{
    public sealed record AirportAirlineId
    {
        public int Value { get; }

        private AirportAirlineId(int value)
        {
            Value = value;
        }

        public static AirportAirlineId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El valor no puede ser menor a 1");

            return new AirportAirlineId(value);
        }

        public static AirportAirlineId CreateEmpty()
        {
            return new AirportAirlineId(0);
        }
    }
}

