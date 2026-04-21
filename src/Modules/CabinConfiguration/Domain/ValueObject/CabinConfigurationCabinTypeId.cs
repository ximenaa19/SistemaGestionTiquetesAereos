namespace GestionAerolineas.src.Modules.CabinConfiguration.Domain.ValueObject
{
    public sealed record CabinConfigurationCabinTypeId
    {
        public int Value { get; }

        private CabinConfigurationCabinTypeId(int value)
        {
            Value = value;
        }

        public static CabinConfigurationCabinTypeId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El valor no puede ser menor a 1");

            return new CabinConfigurationCabinTypeId(value);
        }
    }
}

