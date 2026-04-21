namespace GestionAerolineas.src.Modules.Flights.Domain.ValueObject
{
    public sealed record FlightCode
    {
        public string Value { get; }

        private FlightCode(string value)
        {
            Value = value;
        }

        public static FlightCode Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El codigo_vuelo no puede ser nulo ni vacio");

            var trimmed = value.Trim().ToUpperInvariant();
            if (trimmed.Length > 10)
                throw new ArgumentException("El codigo_vuelo no puede tener mas de 10 caracteres");

            return new FlightCode(trimmed);
        }

        public static string Normalize(string value)
        {
            return (value ?? string.Empty).Trim().ToUpperInvariant();
        }
    }
}

