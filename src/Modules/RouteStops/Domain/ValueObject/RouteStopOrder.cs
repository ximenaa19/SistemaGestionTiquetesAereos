namespace GestionAerolineas.src.Modules.RouteStops.Domain.ValueObject
{
    public sealed record RouteStopOrder
    {
        public int Value { get; }

        private RouteStopOrder(int value)
        {
            Value = value;
        }

        public static RouteStopOrder Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El orden no puede ser menor a 1");

            return new RouteStopOrder(value);
        }
    }
}

