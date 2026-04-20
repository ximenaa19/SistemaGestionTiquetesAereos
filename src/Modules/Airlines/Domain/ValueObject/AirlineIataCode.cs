using System.Text.RegularExpressions;

namespace GestionAerolineas.src.Modules.Airlines.Domain.ValueObject
{
    public sealed record AirlineIataCode
    {
        private static readonly Regex ValidPattern = new("^[A-Z0-9]{2,3}$", RegexOptions.Compiled);

        public string Value { get; }

        private AirlineIataCode(string value)
        {
            Value = value;
        }

        public static AirlineIataCode Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El valor no puede ser nulo ni vacio");
            }

            var candidate = Normalize(value);

            if (!ValidPattern.IsMatch(candidate))
            {
                throw new ArgumentException("El codigo IATA debe tener 2 o 3 caracteres alfanumericos");
            }

            return new AirlineIataCode(candidate);
        }

        public static string Normalize(string value)
        {
            return (value ?? string.Empty).Trim().ToUpperInvariant();
        }
    }
}

