namespace GestionAerolineas.src.Modules.People.Domain.ValueObject
{
    public sealed record PersonFirstNames
    {
        public string Value { get; }

        private PersonFirstNames(string value)
        {
            Value = value;
        }

        public static PersonFirstNames Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El valor no puede ser nulo ni vacio");
            }

            if (value.Length > 100)
            {
                throw new ArgumentException("El valor no puede tener mas de 100 caracteres");
            }

            return new PersonFirstNames(value.Trim());
        }
    }
}

