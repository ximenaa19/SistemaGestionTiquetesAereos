namespace GestionAerolineas.src.Modules.Reservations.Domain.ValueObject;

public sealed record ReservationCreatedAt
{
    public DateTime? Value { get; }

    private ReservationCreatedAt(DateTime? value)
    {
        Value = value;
    }

    public static ReservationCreatedAt CreateOptional(DateTime? value)
    {
        return new ReservationCreatedAt(value);
    }
}

