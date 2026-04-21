namespace GestionAerolineas.src.Modules.Fares.Domain.ValueObject
{
    public sealed record FareBasePrice
    {
        public decimal Value { get; }

        private FareBasePrice(decimal value)
        {
            Value = value;
        }

        public static FareBasePrice Create(decimal value)
        {
            if (value < 0)
                throw new ArgumentException("El precio_base no puede ser negativo");

            return new FareBasePrice(value);
        }
    }
}

