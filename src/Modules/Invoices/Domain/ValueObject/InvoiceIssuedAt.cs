namespace GestionAerolineas.src.Modules.Invoices.Domain.ValueObject;

public record InvoiceIssuedAt(DateTime Value)
{
    public static InvoiceIssuedAt Create(DateTime value)
    {
        if (value == default)
            throw new ArgumentException("fecha_emision no es valida");
        return new InvoiceIssuedAt(value);
    }
}

