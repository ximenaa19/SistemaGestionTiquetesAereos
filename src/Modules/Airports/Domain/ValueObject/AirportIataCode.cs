namespace GestionAerolineas.src.Modules.Airports.Domain.ValueObject;

public sealed record AirportIataCode
{
    public string Value { get; }

    private AirportIataCode(string value)
    {
        Value = value;
    }

    public static AirportIataCode Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El codigo IATA no puede estar vacio");

        var normalized = value.Trim().ToUpperInvariant();

        if (normalized.Length != 3)
            throw new ArgumentException("El codigo IATA debe tener exactamente 3 letras");

        if (!normalized.All(char.IsLetter))
            throw new ArgumentException("El codigo IATA solo puede contener letras");

        return new AirportIataCode(normalized);
    }

    public static string Normalize(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return string.Empty;

        return value.Trim().ToUpperInvariant();
    }
}
