namespace GestionAerolineas.src.Modules.People.Domain.ValueObject
{
    public sealed record PersonDocumentNumber
    {
        public string Value { get; }

        private PersonDocumentNumber(string value)
        {
            Value = value;
        }

        public static PersonDocumentNumber Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El valor no puede ser nulo ni vacio");
            }

            if (value.Length > 30)
            {
                throw new ArgumentException("El valor no puede tener mas de 30 caracteres");
            }

            return new PersonDocumentNumber(value.Trim());
        }

        public static string Normalize(string value)
        {
            return (value ?? string.Empty).Trim().ToUpperInvariant();
        }
    }
}

