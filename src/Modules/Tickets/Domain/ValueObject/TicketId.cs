namespace GestionAerolineas.src.Modules.Tickets.Domain.ValueObject;

public record TicketId(int Value)
{
    public static TicketId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del tiquete no es valido");
        return new TicketId(value);
    }

    public static TicketId CreateEmpty() => new(0);
}

