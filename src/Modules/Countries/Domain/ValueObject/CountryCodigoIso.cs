namespace GestionAerolineas.src.Modules.Countries.Domain.ValueObject;

public sealed record CountryCodigoIso
{
    public string Value { get; }

    public CountryCodigoIso(string value)
    {
        Value = value;
    }

    public static CountryCodigoIso Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("El valor no puede ser nulo ni vacío");
        }

        if (value.Length > 3)
        {
            throw new ArgumentException("El valor no puede tener más de 3 caracteres");
        }

        return new CountryCodigoIso(value);
    }
}


