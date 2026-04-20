namespace GestionAerolineas.src.Modules.Airports.Domain.ValueObject;

public sealed record AirportCityId
{
    public int Value { get; }

    private AirportCityId(int value)
    {
        Value = value;
    }

    public static AirportCityId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new AirportCityId(value);
    }
}
