using System;

namespace GestionAerolineas.src.Modules.PassengerTypes.Domain.ValueObject;

public sealed record PassengerTypeId
{
    public int Value { get; }

    private PassengerTypeId(int value)
    {
        Value = value;
    }

    public static PassengerTypeId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new PassengerTypeId(value);
    }

    public static PassengerTypeId CreateEmpty()
    {
        return new PassengerTypeId(0);
    }
}

