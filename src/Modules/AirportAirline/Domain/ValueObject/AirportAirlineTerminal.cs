namespace GestionAerolineas.src.Modules.AirportAirline.Domain.ValueObject
{
    public sealed record AirportAirlineTerminal
    {
        public string? Value { get; }

        private AirportAirlineTerminal(string? value)
        {
            Value = value;
        }

        public static AirportAirlineTerminal Create(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return new AirportAirlineTerminal((string?)null);

            var trimmed = value.Trim();
            if (trimmed.Length > 20)
                throw new ArgumentException("El terminal no puede tener mas de 20 caracteres");

            return new AirportAirlineTerminal(trimmed);
        }
    }
}

