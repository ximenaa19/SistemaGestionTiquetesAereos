namespace GestionAerolineas.src.Modules.Routes.Domain.ValueObject
{
    public sealed record RouteAirportId
    {
        public int Value { get; }

        private RouteAirportId(int value)
        {
            Value = value;
        }

        public static RouteAirportId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El valor no puede ser menor a 1");

            return new RouteAirportId(value);
        }
    }
}

