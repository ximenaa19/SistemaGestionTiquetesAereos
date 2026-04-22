namespace GestionAerolineas.src.Modules.Invoices.Domain.ValueObject;

public record InvoiceSubtotal(decimal Value)
{
    public static InvoiceSubtotal Create(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("subtotal no puede ser negativo");
        return new InvoiceSubtotal(value);
    }
}

