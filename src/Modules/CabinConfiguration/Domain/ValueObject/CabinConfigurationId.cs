namespace GestionAerolineas.src.Modules.CabinConfiguration.Domain.ValueObject
{
    public sealed record CabinConfigurationId
    {
        public int Value { get; }

        private CabinConfigurationId(int value)
        {
            Value = value;
        }

        public static CabinConfigurationId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El valor no puede ser menor a 1");

            return new CabinConfigurationId(value);
        }

        public static CabinConfigurationId CreateEmpty()
        {
            return new CabinConfigurationId(0);
        }
    }
}

