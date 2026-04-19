using System.Text.RegularExpressions;

namespace GestionAerolineas.src.Modules.InvoiceItemTypes.Domain.ValueObject;

public sealed record InvoiceItemTypeName
{
    public string Value { get; }

    private InvoiceItemTypeName(string value)
    {
        Value = value;
    }

    public static InvoiceItemTypeName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre no puede estar vacio");

        if (value.Length > 100)
            throw new ArgumentException("El nombre no puede superar 100 caracteres");

        var regex = new Regex("^[a-zA-ZÃ¡Ã©Ã­Ã³ÃºÃÃ‰ÃÃ“ÃšÃ±Ã‘ ]+$");

        if (!regex.IsMatch(value))
            throw new ArgumentException("El nombre solo puede contener letras y espacios");

        return new InvoiceItemTypeName(value.Trim());
    }

    public override string ToString() => Value;
}
