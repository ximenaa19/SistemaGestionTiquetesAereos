namespace GestionAerolineas.src.Modules.Airports.Domain.ValueObject;

public sealed record AirportId
{
    public int Value { get; }

    private AirportId(int value)
    {
        Value = value;
    }

    public static AirportId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new AirportId(value);
    }

    public static AirportId CreateEmpty()
    {
        return new AirportId(0);
    }
}
