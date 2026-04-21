namespace GestionAerolineas.src.Modules.CabinConfiguration.Domain.ValueObject
{
    public sealed record CabinConfigurationStartRow
    {
        public int Value { get; }

        private CabinConfigurationStartRow(int value)
        {
            Value = value;
        }

        public static CabinConfigurationStartRow Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("fila_inicio no puede ser menor a 1");

            return new CabinConfigurationStartRow(value);
        }
    }
}

