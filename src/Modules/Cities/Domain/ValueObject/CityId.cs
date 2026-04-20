namespace GestionAerolineas.src.Modules.Cities.Domain.ValueObject
{
    public sealed record CityId
    {
        public int Value { get; }

        private CityId(int value)
        {
            Value = value;
        }

        public static CityId Create(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("El valor no puede ser menor a 1");
            }

            return new CityId(value);
        }

        public static CityId CreateEmpty()
        {
            return new CityId(0);
        }
    }
}


