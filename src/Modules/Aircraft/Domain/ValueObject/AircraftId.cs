namespace GestionAerolineas.src.Modules.Aircraft.Domain.ValueObject
{
    public sealed record AircraftId
    {
        public int Value { get; }

        private AircraftId(int value)
        {
            Value = value;
        }

        public static AircraftId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El valor no puede ser menor a 1");

            return new AircraftId(value);
        }

        public static AircraftId CreateEmpty()
        {
            return new AircraftId(0);
        }
    }
}

