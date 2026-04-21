namespace GestionAerolineas.src.Modules.Reservations.Domain.ValueObject;

public sealed record ReservationExpiresAt
{
    public DateTime? Value { get; }

    private ReservationExpiresAt(DateTime? value)
    {
        Value = value;
    }

    public static ReservationExpiresAt CreateOptional(DateTime? value)
    {
        return new ReservationExpiresAt(value);
    }
}

