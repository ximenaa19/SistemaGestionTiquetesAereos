namespace GestionAerolineas.src.Modules.Tickets.Domain.ValueObject;

public record TicketStatusId(int Value)
{
    public static TicketStatusId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("estado_tiquete_id no es valido");
        return new TicketStatusId(value);
    }
}

