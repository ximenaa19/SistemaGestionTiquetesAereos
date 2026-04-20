namespace GestionAerolineas.src.Modules.Countries.Domain.ValueObject;

public sealed record CountryName
{
    public string Value { get; }

    private CountryName(string value)
    {
        Value = value;
    }

    public static CountryName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre no puede estar vacío");

        var trimmed = value.Trim();

        if (trimmed.Length > 100)
            throw new ArgumentException("Máximo 100 caracteres");

        return new CountryName(trimmed);
    }

    public override string ToString() => Value;
}

