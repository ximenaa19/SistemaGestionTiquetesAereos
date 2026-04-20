namespace GestionAerolineas.src.Modules.Aircraft.Domain.ValueObject
{
    public sealed record AircraftIsActive
    {
        public bool Value { get; }

        private AircraftIsActive(bool value)
        {
            Value = value;
        }

        public static AircraftIsActive Create(bool value)
        {
            return new AircraftIsActive(value);
        }
    }
}

