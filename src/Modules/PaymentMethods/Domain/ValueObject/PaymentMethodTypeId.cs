namespace GestionAerolineas.src.Modules.PaymentMethods.Domain.ValueObject;

public sealed record PaymentMethodTypeId
{
    public int Value { get; }

    private PaymentMethodTypeId(int value)
    {
        Value = value;
    }

    public static PaymentMethodTypeId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new PaymentMethodTypeId(value);
    }
}

