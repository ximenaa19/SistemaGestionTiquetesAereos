namespace GestionAerolineas.src.Modules.Tickets.Domain.ValueObject;

public sealed record TicketUpdatedAt
{
    public DateTime? Value { get; }

    private TicketUpdatedAt(DateTime? value)
    {
        Value = value;
    }

    public static TicketUpdatedAt CreateOptional(DateTime? value)
    {
        return new TicketUpdatedAt(value);
    }
}

