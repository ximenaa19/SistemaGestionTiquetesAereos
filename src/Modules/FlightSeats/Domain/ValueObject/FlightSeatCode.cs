using System.Text.RegularExpressions;

namespace GestionAerolineas.src.Modules.FlightSeats.Domain.ValueObject
{
    public sealed partial record FlightSeatCode
    {
        public string Value { get; }

        private FlightSeatCode(string value)
        {
            Value = value;
        }

        public static FlightSeatCode Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El codigo_asiento no puede ser nulo ni vacio");

            var normalized = Normalize(value);
            if (normalized.Length > 5)
                throw new ArgumentException("El codigo_asiento no puede tener mas de 5 caracteres");

            if (!SeatCodeRegex().IsMatch(normalized))
                throw new ArgumentException("El codigo_asiento debe tener formato tipo '12A'");

            return new FlightSeatCode(normalized);
        }

        public static string Normalize(string value)
        {
            return (value ?? string.Empty).Trim().ToUpperInvariant();
        }

        [GeneratedRegex(@"^\d{1,4}[A-Z]$")]
        private static partial Regex SeatCodeRegex();
    }
}

