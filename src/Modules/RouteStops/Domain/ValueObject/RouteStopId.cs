namespace GestionAerolineas.src.Modules.RouteStops.Domain.ValueObject
{
    public sealed record RouteStopId
    {
        public int Value { get; }

        private RouteStopId(int value)
        {
            Value = value;
        }

        public static RouteStopId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El valor no puede ser menor a 1");

            return new RouteStopId(value);
        }

        public static RouteStopId CreateEmpty()
        {
            return new RouteStopId(0);
        }
    }
}

