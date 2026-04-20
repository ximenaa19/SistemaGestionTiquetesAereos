namespace GestionAerolineas.src.Modules.Airlines.Domain.ValueObject
{
    public sealed record AirlineIsActive
    {
        public bool Value { get; }

        private AirlineIsActive(bool value)
        {
            Value = value;
        }

        public static AirlineIsActive Create(bool value)
        {
            return new AirlineIsActive(value);
        }
    }
}

