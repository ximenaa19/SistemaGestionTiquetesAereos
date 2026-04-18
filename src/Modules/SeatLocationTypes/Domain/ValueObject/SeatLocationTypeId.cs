using System;

namespace GestionAerolineas.src.Modules.SeatLocationTypes.Domain.ValueObject;

public sealed record SeatLocationTypeId
{
    public int Value { get; }

    private SeatLocationTypeId(int value)
    {
        Value = value;
    }

    public static SeatLocationTypeId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new SeatLocationTypeId(value);
    }

    public static SeatLocationTypeId CreateEmpty()
    {
        return new SeatLocationTypeId(0);
    }
}

