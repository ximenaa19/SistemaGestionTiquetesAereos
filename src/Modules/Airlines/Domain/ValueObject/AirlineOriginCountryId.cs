namespace GestionAerolineas.src.Modules.Airlines.Domain.ValueObject
{
    public sealed record AirlineOriginCountryId
    {
        public int Value { get; }

        private AirlineOriginCountryId(int value)
        {
            Value = value;
        }

        public static AirlineOriginCountryId Create(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("El valor no puede ser menor a 1");
            }

            return new AirlineOriginCountryId(value);
        }
    }
}

