namespace GestionAerolineas.src.Modules.PaymentStates.Domain.ValueObject;

public sealed record PaymentStateId
{
    public int Value { get; }

    private PaymentStateId(int value)
    {
        Value = value;
    }

    public static PaymentStateId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new PaymentStateId(value);
    }

    public static PaymentStateId CreateEmpty()
    {
        return new PaymentStateId(0);
    }
}
