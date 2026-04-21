namespace GestionAerolineas.src.Modules.Fares.Domain.ValueObject
{
    public sealed record FareCabinTypeId
    {
        public int Value { get; }

        private FareCabinTypeId(int value)
        {
            Value = value;
        }

        public static FareCabinTypeId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El tipo_cabina_id no puede ser menor a 1");

            return new FareCabinTypeId(value);
        }
    }
}

