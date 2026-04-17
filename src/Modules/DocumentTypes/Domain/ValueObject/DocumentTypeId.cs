using System;

namespace GestionAerolineas.src.Modules.DocumentTypes.Domain.ValueObject;

public sealed record DocumentTypeId
{
    public int Value { get; }

    private DocumentTypeId(int value)
    {
        Value = value;
    }

    public static DocumentTypeId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El Id debe ser mayor a 0");

        return new DocumentTypeId(value);
    }
}