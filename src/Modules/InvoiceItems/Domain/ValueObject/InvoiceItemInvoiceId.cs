namespace GestionAerolineas.src.Modules.InvoiceItems.Domain.ValueObject;

public record InvoiceItemInvoiceId(int Value)
{
    public static InvoiceItemInvoiceId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("factura_id no es valido");
        return new InvoiceItemInvoiceId(value);
    }
}

