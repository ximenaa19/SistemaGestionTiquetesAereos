using System.Text.RegularExpressions;

namespace GestionAerolineas.src.Modules.Aircraft.Domain.ValueObject
{
    public sealed record AircraftRegistration
    {
        private static readonly Regex ValidPattern = new("^[A-Z0-9-]{2,20}$", RegexOptions.Compiled);

        public string Value { get; }

        private AircraftRegistration(string value)
        {
            Value = value;
        }

        public static AircraftRegistration Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("La matricula no puede estar vacia");

            var normalized = Normalize(value);

            if (normalized.Length > 20)
                throw new ArgumentException("La matricula no puede tener mas de 20 caracteres");

            if (!ValidPattern.IsMatch(normalized))
                throw new ArgumentException("La matricula solo puede contener letras, numeros y guion");

            return new AircraftRegistration(normalized);
        }

        public static string Normalize(string value)
        {
            return (value ?? string.Empty).Trim().ToUpperInvariant();
        }
    }
}

