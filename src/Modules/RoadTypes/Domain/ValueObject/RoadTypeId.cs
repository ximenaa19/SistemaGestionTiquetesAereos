using System;

namespace GestionAerolineas.src.Modules.RoadTypes.Domain.ValueObject;

public sealed record RoadTypeId
{
    public int Value { get; }

    private RoadTypeId(int value)
    {
        Value = value;
    }

    public static RoadTypeId Create(int value)
    {
        if (value <= 0)
        {
            throw new ArgumentException("El valor no puede ser menor a 1");
        }

        return new RoadTypeId(value);
    }
}
