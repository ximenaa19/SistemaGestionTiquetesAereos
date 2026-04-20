namespace GestionAerolineas.src.Modules.Aircraft.Domain.ValueObject
{
    public sealed record AircraftModelId
    {
        public int Value { get; }

        private AircraftModelId(int value)
        {
            Value = value;
        }

        public static AircraftModelId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El valor no puede ser menor a 1");

            return new AircraftModelId(value);
        }
    }
}

