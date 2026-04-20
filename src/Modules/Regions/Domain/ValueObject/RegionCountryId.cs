namespace GestionAerolineas.src.Modules.Regions.Domain.ValueObject;

public sealed record RegionCountryId
{
    public int Value { get; }

    private RegionCountryId(int value)
    {
        Value = value;
    }

    public static RegionCountryId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new RegionCountryId(value);
    }
}

