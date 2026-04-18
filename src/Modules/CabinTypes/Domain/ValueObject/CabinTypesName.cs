using System;

namespace GestionAerolineas.src.Modules.CabinTypes.Domain.ValueObject;

public class CabinTypesName
{
    public string Value { get; }
    public bool IsNew => Value == null;

    private CabinTypesName(string value)
    {
        Value = value;
    }

    public static CabinTypesName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre no puede estar vacío");

        return new CabinTypesName(value);
    }
    public override string ToString() => Value;

}
