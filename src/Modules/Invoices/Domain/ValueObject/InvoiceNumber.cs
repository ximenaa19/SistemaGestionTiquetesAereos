namespace GestionAerolineas.src.Modules.Invoices.Domain.ValueObject;

public record InvoiceNumber(string Value)
{
    public static InvoiceNumber Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("numero_factura es obligatorio");

        var trimmed = value.Trim();
        if (trimmed.Length > 30)
            throw new ArgumentException("numero_factura excede 30 caracteres");

        return new InvoiceNumber(trimmed);
    }

    public static string Normalize(string value) => (value ?? string.Empty).Trim().ToUpperInvariant();
}

