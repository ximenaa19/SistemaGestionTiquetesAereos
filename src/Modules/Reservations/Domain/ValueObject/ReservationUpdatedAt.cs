namespace GestionAerolineas.src.Modules.Reservations.Domain.ValueObject;

public sealed record ReservationUpdatedAt
{
    public DateTime? Value { get; }

    private ReservationUpdatedAt(DateTime? value)
    {
        Value = value;
    }

    public static ReservationUpdatedAt CreateOptional(DateTime? value)
    {
        return new ReservationUpdatedAt(value);
    }
}

