namespace GestionAerolineas.src.Modules.Flights.Domain.ValueObject
{
    public sealed record FlightRouteId
    {
        public int Value { get; }

        private FlightRouteId(int value)
        {
            Value = value;
        }

        public static FlightRouteId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El ruta_id no puede ser menor a 1");

            return new FlightRouteId(value);
        }
    }
}

