namespace GestionAerolineas.src.Modules.Regions.Domain.ValueObject;

public sealed record RegionType
{
    public string Value { get; }

    private RegionType(string value)
    {
        Value = value;
    }

    public static RegionType Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("El valor no puede ser nulo ni vacío");
        }

        if (value.Length > 30)
        {
            throw new ArgumentException("El valor no puede tener más de 30 caracteres");
        }

        return new RegionType(value.Trim());
    }

    public static string Normalize(string value)
    {
        return (value ?? string.Empty).Trim().ToUpperInvariant();
    }
}


