namespace GestionAerolineas.src.Modules.Invoices.Domain.ValueObject;

public record InvoiceTaxes(decimal Value)
{
    public static InvoiceTaxes Create(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("impuestos no puede ser negativo");
        return new InvoiceTaxes(value);
    }
}

