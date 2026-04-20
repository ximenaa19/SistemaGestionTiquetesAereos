namespace GestionAerolineas.src.Modules.Airports.Domain.ValueObject;

public sealed record AirportIcaoCode
{
    public string Value { get; }

    private AirportIcaoCode(string value)
    {
        Value = value;
    }

    public static AirportIcaoCode Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El codigo ICAO no puede estar vacio");

        var normalized = value.Trim().ToUpperInvariant();

        if (normalized.Length != 4)
            throw new ArgumentException("El codigo ICAO debe tener exactamente 4 letras");

        if (!normalized.All(char.IsLetter))
            throw new ArgumentException("El codigo ICAO solo puede contener letras");

        return new AirportIcaoCode(normalized);
    }

    public static AirportIcaoCode? CreateOptional(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;

        return Create(value);
    }

    public static string Normalize(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return string.Empty;

        return value.Trim().ToUpperInvariant();
    }
}
