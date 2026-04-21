namespace GestionAerolineas.src.Modules.RouteStops.Domain.ValueObject
{
    public sealed record RouteStopRouteId
    {
        public int Value { get; }

        private RouteStopRouteId(int value)
        {
            Value = value;
        }

        public static RouteStopRouteId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El valor no puede ser menor a 1");

            return new RouteStopRouteId(value);
        }
    }
}

