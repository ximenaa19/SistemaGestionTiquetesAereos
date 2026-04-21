namespace GestionAerolineas.src.Modules.Fares.Domain.ValueObject
{
    public sealed record FareValidFromDate
    {
        public DateTime? Value { get; }

        private FareValidFromDate(DateTime? value)
        {
            Value = value?.Date;
        }

        public static FareValidFromDate Create(DateTime? value)
        {
            return new FareValidFromDate(value);
        }
    }
}

