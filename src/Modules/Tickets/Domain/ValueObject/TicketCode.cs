namespace GestionAerolineas.src.Modules.Tickets.Domain.ValueObject;

public record TicketCode(string Value)
{
    public static TicketCode Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("codigo_tiquete es obligatorio");

        var trimmed = value.Trim();
        if (trimmed.Length > 30)
            throw new ArgumentException("codigo_tiquete excede 30 caracteres");

        return new TicketCode(trimmed);
    }

    public static string Normalize(string value) => (value ?? string.Empty).Trim().ToUpperInvariant();
}

