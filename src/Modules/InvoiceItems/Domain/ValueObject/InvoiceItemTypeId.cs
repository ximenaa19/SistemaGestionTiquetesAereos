namespace GestionAerolineas.src.Modules.InvoiceItems.Domain.ValueObject;

public record InvoiceItemTypeId(int Value)
{
    public static InvoiceItemTypeId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("tipo_item_id no es valido");
        return new InvoiceItemTypeId(value);
    }
}

