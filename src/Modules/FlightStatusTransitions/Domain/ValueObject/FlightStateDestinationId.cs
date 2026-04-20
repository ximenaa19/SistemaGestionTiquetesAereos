namespace GestionAerolineas.src.Modules.FlightStatusTransitions.Domain.ValueObject;

public sealed record FlightStateDestinationId
{
    public int Value { get; }

    private FlightStateDestinationId(int value)
    {
        Value = value;
    }

    public static FlightStateDestinationId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new FlightStateDestinationId(value);
    }
}

