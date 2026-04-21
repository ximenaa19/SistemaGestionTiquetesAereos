namespace GestionAerolineas.src.Modules.Payments.Domain.ValueObject;

public sealed record PaymentUpdatedAt
{
    public DateTime? Value { get; }

    private PaymentUpdatedAt(DateTime? value)
    {
        Value = value;
    }

    public static PaymentUpdatedAt CreateOptional(DateTime? value)
    {
        return new PaymentUpdatedAt(value);
    }
}

