namespace GestionAerolineas.src.Modules.InvoiceItems.Domain.ValueObject;

public record InvoiceItemSubtotal(decimal Value)
{
    public static InvoiceItemSubtotal Create(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("subtotal no puede ser negativo");
        return new InvoiceItemSubtotal(value);
    }
}

