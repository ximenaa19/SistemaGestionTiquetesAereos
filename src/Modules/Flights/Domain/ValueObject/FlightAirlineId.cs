namespace GestionAerolineas.src.Modules.Flights.Domain.ValueObject
{
    public sealed record FlightAirlineId
    {
        public int Value { get; }

        private FlightAirlineId(int value)
        {
            Value = value;
        }

        public static FlightAirlineId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El aerolinea_id no puede ser menor a 1");

            return new FlightAirlineId(value);
        }
    }
}

