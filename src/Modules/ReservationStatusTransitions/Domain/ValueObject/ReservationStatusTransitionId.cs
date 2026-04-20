namespace GestionAerolineas.src.Modules.ReservationStatusTransitions.Domain.ValueObject;

public sealed record ReservationStatusDestinationId
{
    public int Value { get; }

    private ReservationStatusDestinationId(int value)
    {
        Value = value;
    }

    public static ReservationStatusDestinationId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new ReservationStatusDestinationId(value);
    }
}
