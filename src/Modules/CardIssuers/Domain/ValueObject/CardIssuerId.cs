using System;

namespace GestionAerolineas.src.Modules.CardIssuers.Domain.ValueObject;

public sealed record CardIssuerId
{
    public int Value { get; }

    private CardIssuerId(int value)
    {
        Value = value;
    }

    public static CardIssuerId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new CardIssuerId(value);
    }

    public static CardIssuerId CreateEmpty()
    {
        return new CardIssuerId(0);
    }
}
