namespace GestionAerolineas.src.Modules.FlightStatusTransitions.Domain.ValueObject;

public sealed record FlightStatusTransitionId
{
    public int Value { get; }

    private FlightStatusTransitionId(int value)
    {
        Value = value;
    }

    public static FlightStatusTransitionId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new FlightStatusTransitionId(value);
    }

    public static FlightStatusTransitionId CreateEmpty()
    {
        return new FlightStatusTransitionId(0);
    }
}

