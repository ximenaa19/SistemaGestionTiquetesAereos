using System;

namespace GestionAerolineas.src.Modules.ReservationStatuses.Domain.ValueObject;

public sealed record ReservationStatusId
{
    public int Value { get; }

    private ReservationStatusId(int value)
    {
        Value = value;
    }

    public static ReservationStatusId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new ReservationStatusId(value);
    }

    public static ReservationStatusId CreateEmpty()
    {
        return new ReservationStatusId(0);
    }
}

