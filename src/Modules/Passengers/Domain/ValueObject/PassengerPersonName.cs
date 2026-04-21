namespace GestionAerolineas.src.Modules.Passengers.Domain.ValueObject;

public sealed record PassengerPersonName
{
    public string Value { get; }

    private PassengerPersonName(string value)
    {
        Value = value;
    }

    public static PassengerPersonName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre de la persona no puede estar vacio");

        return new PassengerPersonName(value.Trim());
    }

    public static string Normalize(string value)
    {
        return (value ?? string.Empty).Trim().ToUpperInvariant();
    }
}
