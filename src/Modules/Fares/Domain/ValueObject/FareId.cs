namespace GestionAerolineas.src.Modules.Fares.Domain.ValueObject
{
    public sealed record FareId
    {
        public int Value { get; }

        private FareId(int value)
        {
            Value = value;
        }

        public static FareId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El id no puede ser menor a 1");

            return new FareId(value);
        }

        public static FareId CreateEmpty()
        {
            return new FareId(0);
        }
    }
}

