namespace GestionAerolineas.src.Modules.Routes.Domain.ValueObject
{
    public sealed record RouteId
    {
        public int Value { get; }

        private RouteId(int value)
        {
            Value = value;
        }

        public static RouteId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El valor no puede ser menor a 1");

            return new RouteId(value);
        }

        public static RouteId CreateEmpty()
        {
            return new RouteId(0);
        }
    }
}

