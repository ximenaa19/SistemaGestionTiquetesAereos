namespace GestionAerolineas.src.Modules.Countries.Domain.ValueObject;

public sealed record CountryId
{
    public int Value { get; }

    private CountryId(int value)
    {
        Value = value;
    }

    public static CountryId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new CountryId(value);
    }

    public static CountryId CreateEmpty()
    {
        return new CountryId(0);
    }
}

