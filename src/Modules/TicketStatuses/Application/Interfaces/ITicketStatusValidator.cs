using GestionAerolineas.src.Modules.TicketStatuses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.TicketStatuses.Application.Interfaces;

public interface ITicketStatusValidator
{
    Task ValidateNameAsync(TicketStatusName name, TicketStatusId? currentId = null);
}
