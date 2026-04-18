namespace GestionAerolineas.src.Modules.TicketStatuses.Domain.ValueObject;

public sealed record TicketStatusId
{
    public int Value { get; }

    private TicketStatusId(int value)
    {
        Value = value;
    }

    public static TicketStatusId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El valor no puede ser menor a 1");

        return new TicketStatusId(value);
    }

    public static TicketStatusId CreateEmpty()
    {
        return new TicketStatusId(0);
    }
}
