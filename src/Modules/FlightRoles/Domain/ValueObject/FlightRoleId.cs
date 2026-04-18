using System;

namespace GestionAerolineas.src.Modules.FlightRoles.Domain.ValueObject;

public sealed record FlightRoleId
{
    public int Value { get; }

    private FlightRoleId(int value)
    {
        Value = value;
    }

    public static FlightRoleId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new FlightRoleId(value);
    }

    public static FlightRoleId CreateEmpty()
    {
        return new FlightRoleId(0);
    }
}

