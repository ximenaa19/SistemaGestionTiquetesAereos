namespace GestionAerolineas.src.Modules.RouteStops.Domain.ValueObject
{
    public sealed record RouteStopStopAirportId
    {
        public int Value { get; }

        private RouteStopStopAirportId(int value)
        {
            Value = value;
        }

        public static RouteStopStopAirportId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El aeropuerto_escala_id no puede ser menor a 1");

            return new RouteStopStopAirportId(value);
        }
    }
}

