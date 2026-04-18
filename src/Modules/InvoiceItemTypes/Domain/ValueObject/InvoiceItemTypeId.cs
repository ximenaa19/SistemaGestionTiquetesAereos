namespace GestionAerolineas.src.Modules.InvoiceItemTypes.Domain.ValueObject;

public sealed record InvoiceItemTypeId
{
    public int Value { get; }

    private InvoiceItemTypeId(int value)
    {
        Value = value;
    }

    public static InvoiceItemTypeId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new InvoiceItemTypeId(value);
    }

    public static InvoiceItemTypeId CreateEmpty()
    {
        return new InvoiceItemTypeId(0);
    }
}
