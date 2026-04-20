namespace GestionAerolineas.src.Modules.Aircraft.Domain.ValueObject
{
    public sealed record AircraftAirlineId
    {
        public int Value { get; }

        private AircraftAirlineId(int value)
        {
            Value = value;
        }

        public static AircraftAirlineId Create(int value)
        {
            if (value <= 0)
                throw new ArgumentException("El valor no puede ser menor a 1");

            return new AircraftAirlineId(value);
        }
    }
}

