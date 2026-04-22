namespace GestionAerolineas.src.Modules.InvoiceItems.Domain.ValueObject;

public record InvoiceItemDescription(string Value)
{
    public static InvoiceItemDescription Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("descripcion es obligatoria");

        var trimmed = value.Trim();
        if (trimmed.Length > 200)
            throw new ArgumentException("descripcion excede 200 caracteres");

        return new InvoiceItemDescription(trimmed);
    }
}

