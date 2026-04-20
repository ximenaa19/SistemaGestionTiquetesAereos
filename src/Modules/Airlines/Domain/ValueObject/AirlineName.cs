namespace GestionAerolineas.src.Modules.Airlines.Domain.ValueObject
{
    public sealed record AirlineName
    {
        public string Value { get; }

        private AirlineName(string value)
        {
            Value = value;
        }

        public static AirlineName Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El valor no puede ser nulo ni vacio");
            }

            if (value.Length > 150)
            {
                throw new ArgumentException("El valor no puede tener mas de 150 caracteres");
            }

            return new AirlineName(value.Trim());
        }

        public static string Normalize(string value)
        {
            return (value ?? string.Empty).Trim().ToUpperInvariant();
        }
    }
}

