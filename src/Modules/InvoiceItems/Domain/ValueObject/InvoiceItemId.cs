namespace GestionAerolineas.src.Modules.InvoiceItems.Domain.ValueObject;

public record InvoiceItemId(int Value)
{
    public static InvoiceItemId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del item no es valido");
        return new InvoiceItemId(value);
    }

    public static InvoiceItemId CreateEmpty() => new(0);
}

