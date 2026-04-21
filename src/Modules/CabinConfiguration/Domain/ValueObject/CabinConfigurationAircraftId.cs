namespace GestionAerolineas.src.Modules.CabinConfiguration.Domain.ValueObject
{
    public sealed record CabinConfigurationAircraftId
    {
        public int Value { get; }

        private CabinConfigurationAircraftId(int value)
        {
            Value = value;
        }

        public static CabinConfigurationAircraftId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El valor no puede ser menor a 1");

            return new CabinConfigurationAircraftId(value);
        }
    }
}

