namespace GestionAerolineas.src.Modules.Cities.Domain.ValueObject
{
    public sealed record CityName
    {
        public string Value { get; }

        private CityName(string value)
        {
            Value = value;
        }

        public static CityName Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El valor no puede ser nulo ni vacío");
            }

            if (value.Length > 100)
            {
                throw new ArgumentException("El valor no puede tener más de 100 caracteres");
            }

            return new CityName(value.Trim());
        }

        public static string Normalize(string value)
        {
            return (value ?? string.Empty).Trim().ToUpperInvariant();
        }
    }
}


