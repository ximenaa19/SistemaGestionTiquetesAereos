namespace GestionAerolineas.src.Modules.ReservationStatusTransitions.Domain.ValueObject;

public sealed record ReservationStatusTransitionId
{
    public int Value { get; }

    private ReservationStatusTransitionId(int value)
    {
        Value = value;
    }

    public static ReservationStatusTransitionId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new ReservationStatusTransitionId(value);
    }

    public static ReservationStatusTransitionId CreateEmpty()
    {
        return new ReservationStatusTransitionId(0);
    }
}
