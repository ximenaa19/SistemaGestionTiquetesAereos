namespace GestionAerolineas.src.Modules.Payments.Domain.ValueObject;

public sealed record PaymentCreatedAt
{
    public DateTime? Value { get; }

    private PaymentCreatedAt(DateTime? value)
    {
        Value = value;
    }

    public static PaymentCreatedAt CreateOptional(DateTime? value)
    {
        return new PaymentCreatedAt(value);
    }
}

