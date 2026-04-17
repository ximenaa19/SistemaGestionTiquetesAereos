namespace GestionAerolineas.src.Modules.Countries.Domain.ValueObject;

public sealed record CountryId
{
    public string Value { get; }

    public CountryId(string value)
    {
        Value = value;
    }

    public static CountryId Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("El valor no puede ser nulo ni vacío");
        }

        return new CountryId(value.Trim());
    }
}


