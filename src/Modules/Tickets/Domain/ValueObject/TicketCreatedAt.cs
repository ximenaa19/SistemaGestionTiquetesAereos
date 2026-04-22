namespace GestionAerolineas.src.Modules.Tickets.Domain.ValueObject;

public sealed record TicketCreatedAt
{
    public DateTime? Value { get; }

    private TicketCreatedAt(DateTime? value)
    {
        Value = value;
    }

    public static TicketCreatedAt CreateOptional(DateTime? value)
    {
        return new TicketCreatedAt(value);
    }
}

