namespace GestionAerolineas.src.Modules.Cities.Domain.ValueObject
{
    public class CityRegionId
    {
        public int Value { get; }

        public CityRegionId(int value)
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


