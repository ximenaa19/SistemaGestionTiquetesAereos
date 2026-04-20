namespace GestionAerolineas.src.Modules.Cities.Domain.ValueObject
{
    public sealed record CityRegionId
    {
        public int Value { get; }

        private CityRegionId(int value)
        {
            Value = value;
        }

        public static CityRegionId Create(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("El valor no puede ser menor a 1");
            }

            return new CityRegionId(value);
        }
    }
}


