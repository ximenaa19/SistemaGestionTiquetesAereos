namespace GestionAerolineas.src.Modules.Invoices.Domain.ValueObject;

public sealed record InvoiceCreatedAt
{
    public DateTime? Value { get; }

    private InvoiceCreatedAt(DateTime? value)
    {
        Value = value;
    }

    public static InvoiceCreatedAt CreateOptional(DateTime? value)
    {
        return new InvoiceCreatedAt(value);
    }
}

