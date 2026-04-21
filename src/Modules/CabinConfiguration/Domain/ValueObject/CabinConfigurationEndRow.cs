namespace GestionAerolineas.src.Modules.CabinConfiguration.Domain.ValueObject
{
    public sealed record CabinConfigurationEndRow
    {
        public int Value { get; }

        private CabinConfigurationEndRow(int value)
        {
            Value = value;
        }

        public static CabinConfigurationEndRow Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("fila_fin no puede ser menor a 1");

            return new CabinConfigurationEndRow(value);
        }
    }
}
