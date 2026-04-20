namespace GestionAerolineas.src.Modules.PaymentMethods.Domain.ValueObject;

public sealed record PaymentMethodId
{
    public int Value { get; }

    private PaymentMethodId(int value)
    {
        Value = value;
    }

    public static PaymentMethodId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new PaymentMethodId(value);
    }

    public static PaymentMethodId CreateEmpty()
    {
        return new PaymentMethodId(0);
    }
}

