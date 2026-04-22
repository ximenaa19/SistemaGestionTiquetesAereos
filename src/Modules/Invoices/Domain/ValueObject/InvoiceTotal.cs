namespace GestionAerolineas.src.Modules.Invoices.Domain.ValueObject;

public record InvoiceTotal(decimal Value)
{
    public static InvoiceTotal Create(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("total no puede ser negativo");
        return new InvoiceTotal(value);
    }
}

