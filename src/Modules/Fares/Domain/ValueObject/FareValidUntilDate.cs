namespace GestionAerolineas.src.Modules.Fares.Domain.ValueObject
{
    public sealed record FareValidUntilDate
    {
        public DateTime? Value { get; }

        private FareValidUntilDate(DateTime? value)
        {
            Value = value?.Date;
        }

        public static FareValidUntilDate Create(DateTime? value)
        {
            return new FareValidUntilDate(value);
        }
    }
}

