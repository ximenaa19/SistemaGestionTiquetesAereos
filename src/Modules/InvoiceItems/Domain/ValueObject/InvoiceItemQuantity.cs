namespace GestionAerolineas.src.Modules.InvoiceItems.Domain.ValueObject;

public record InvoiceItemQuantity(int Value)
{
    public static InvoiceItemQuantity Create(int value)
    {
        if (value < 1)
            throw new ArgumentException("cantidad debe ser >= 1");
        return new InvoiceItemQuantity(value);
    }
}

