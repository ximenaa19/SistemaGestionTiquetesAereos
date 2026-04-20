namespace GestionAerolineas.src.Modules.FlightStatusTransitions.Domain.ValueObject;

public sealed record FlightStateOriginId
{
    public int Value { get; }

    private FlightStateOriginId(int value)
    {
        Value = value;
    }

    public static FlightStateOriginId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new FlightStateOriginId(value);
    }
}

