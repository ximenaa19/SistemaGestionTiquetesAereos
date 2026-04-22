namespace GestionAerolineas.src.Modules.Invoices.Domain.ValueObject;

public record InvoiceId(int Value)
{
    public static InvoiceId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id de la factura no es valido");
        return new InvoiceId(value);
    }

    public static InvoiceId CreateEmpty() => new(0);
}

