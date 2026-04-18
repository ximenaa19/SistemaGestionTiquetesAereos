using System;

namespace GestionAerolineas.src.Modules.PhoneCodes.Domain.ValueObject;

public sealed record PhoneCodeId
{
    public int Value { get; }

    private PhoneCodeId(int value)
    {
        Value = value;
    }

    public static PhoneCodeId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new PhoneCodeId(value);
    }

    public static PhoneCodeId CreateEmpty()
    {
        return new PhoneCodeId(0);
    }
}

