namespace GestionAerolineas.src.Modules.PaymentMethods.Domain.ValueObject;

public sealed record CardTypeId
{
    public int Value { get; }

    private CardTypeId(int value)
    {
        Value = value;
    }

    public static CardTypeId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new CardTypeId(value);
    }
}

