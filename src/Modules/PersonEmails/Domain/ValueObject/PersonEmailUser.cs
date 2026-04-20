using System.Text.RegularExpressions;

namespace GestionAerolineas.src.Modules.PersonEmails.Domain.ValueObject
{
    public sealed record PersonEmailUser
    {
        private static readonly Regex ValidPattern = new("^[A-Z0-9._%+-]{1,100}$", RegexOptions.Compiled);

        public string Value { get; }

        private PersonEmailUser(string value)
        {
            Value = value;
        }

        public static PersonEmailUser Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El usuario_email no puede estar vacio");

            var normalized = Normalize(value);

            if (normalized.Length > 100)
                throw new ArgumentException("El usuario_email no puede tener mas de 100 caracteres");

            if (normalized.Contains('@'))
                throw new ArgumentException("El usuario_email no debe incluir '@'");

            if (!ValidPattern.IsMatch(normalized))
                throw new ArgumentException("El usuario_email tiene un formato invalido");

            return new PersonEmailUser(normalized);
        }

        public static string Normalize(string value)
        {
            return (value ?? string.Empty).Trim().ToUpperInvariant();
        }
    }
}

