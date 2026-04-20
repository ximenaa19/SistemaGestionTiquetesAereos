namespace GestionAerolineas.src.Modules.ReservationStatusTransitions.Domain.ValueObject;

public sealed record ReservationStatusOriginId
{
    public int Value { get; }

    private ReservationStatusOriginId(int value)
    {
        Value = value;
    }

    public static ReservationStatusOriginId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new ReservationStatusOriginId(value);
    }
}
