namespace GestionAerolineas.src.Modules.Countries.Domain.ValueObject;

public sealed record CountryCodigoIso
{
    public string Value { get; }

    private CountryCodigoIso(string value)
    {
        Value = value;
    }

    public static CountryCodigoIso Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El código ISO no puede estar vacío");

        var trimmed = value.Trim().ToUpperInvariant();

        if (trimmed.Length != 3)
            throw new ArgumentException("El código ISO debe tener exactamente 3 caracteres");

        if (!trimmed.All(char.IsLetter))
            throw new ArgumentException("El código ISO solo puede contener letras");

        return new CountryCodigoIso(trimmed);
    }

    public static string Normalize(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return string.Empty;

        return value.Trim().ToUpperInvariant();
    }

    public override string ToString() => Value;
}

