namespace GestionAerolineas.src.Modules.InvoiceItems.Domain.ValueObject;

public record InvoiceItemUnitPrice(decimal Value)
{
    public static InvoiceItemUnitPrice Create(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("precio_unitario no puede ser negativo");
        return new InvoiceItemUnitPrice(value);
    }
}

