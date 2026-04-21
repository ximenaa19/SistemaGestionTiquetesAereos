namespace GestionAerolineas.src.Modules.CabinConfiguration.Domain.ValueObject
{
    public sealed record CabinConfigurationSeatsPerRow
    {
        public int Value { get; }

        private CabinConfigurationSeatsPerRow(int value)
        {
            Value = value;
        }

        public static CabinConfigurationSeatsPerRow Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("asientos_por_fila no puede ser menor a 1");

            return new CabinConfigurationSeatsPerRow(value);
        }
    }
}

