namespace GestionAerolineas.src.Modules.Checkins.Domain.ValueObject;

public record CheckinTicketId(int Value)
{
    public static CheckinTicketId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("tiquete_id no es valido");
        return new CheckinTicketId(value);
    }
}

