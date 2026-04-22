namespace GestionAerolineas.src.Modules.Tickets.Domain.ValueObject;

public record TicketIssuedAt(DateTime Value)
{
    public static TicketIssuedAt Create(DateTime value)
    {
        if (value == default)
            throw new ArgumentException("fecha_emision no es valida");
        return new TicketIssuedAt(value);
    }
}

