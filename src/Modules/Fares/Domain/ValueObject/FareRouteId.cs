namespace GestionAerolineas.src.Modules.Fares.Domain.ValueObject
{
    public sealed record FareRouteId
    {
        public int Value { get; }

        private FareRouteId(int value)
        {
            Value = value;
        }

        public static FareRouteId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("La ruta_id no puede ser menor a 1");

            return new FareRouteId(value);
        }
    }
}

