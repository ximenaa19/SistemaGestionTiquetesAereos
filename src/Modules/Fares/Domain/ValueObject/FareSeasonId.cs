namespace GestionAerolineas.src.Modules.Fares.Domain.ValueObject
{
    public sealed record FareSeasonId
    {
        public int Value { get; }

        private FareSeasonId(int value)
        {
            Value = value;
        }

        public static FareSeasonId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("La temporada_id no puede ser menor a 1");

            return new FareSeasonId(value);
        }
    }
}

