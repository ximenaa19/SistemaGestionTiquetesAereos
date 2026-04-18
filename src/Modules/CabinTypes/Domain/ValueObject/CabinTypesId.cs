using System;

namespace GestionAerolineas.src.Modules.CabinTypes.Domain.ValueObject;

public class CabinTypesId
{
    public int Value { get; }

    private CabinTypesId(int value)
    {
        Value = value;
    }

    public static CabinTypesId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new CabinTypesId(value);
    }

    public static CabinTypesId CreateEmpty()
    {
        return new CabinTypesId(0);
    }


}
