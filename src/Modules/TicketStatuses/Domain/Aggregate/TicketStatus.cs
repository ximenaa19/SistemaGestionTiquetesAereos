using GestionAerolineas.src.Modules.TicketStatuses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.TicketStatuses.Domain.Aggregate;

public class TicketStatus
{
    public TicketStatusId Id { get; private set; }
    public TicketStatusName Name { get; private set; }

    private TicketStatus(TicketStatusId id, TicketStatusName name)
    {
        Id = id;
        Name = name;
    }

    public static TicketStatus Create(TicketStatusId id, TicketStatusName name)
    {
        return new TicketStatus(id, name);
    }

    public static TicketStatus CreateNew(TicketStatusName name)
    {
        return new TicketStatus(TicketStatusId.CreateEmpty(), name);
    }
}
