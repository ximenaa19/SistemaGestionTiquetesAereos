namespace GestionAerolineas.src.Modules.Seasons.Domain.ValueObject;

public sealed record SeasonDescription
{
    public string? Value { get; }

    private SeasonDescription(string? value)
    {
        Value = value;
    }

    public static SeasonDescription Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return new SeasonDescription((string?)null);

        var trimmed = value.Trim();

        if (trimmed.Length > 150)
            throw new ArgumentException("La descripcion no puede superar 150 caracteres");

        return new SeasonDescription(trimmed);
    }

    public override string ToString() => Value ?? string.Empty;
}
