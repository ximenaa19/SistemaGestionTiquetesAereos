using GestionAerolineas.src.Modules.TicketStatuses.Domain.Aggregate;
using GestionAerolineas.src.Modules.TicketStatuses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.TicketStatuses.Domain.Repositories;

public interface ITicketStatusRepository
{
    Task<IEnumerable<TicketStatus>> GetAllAsync();
    Task<TicketStatus?> GetByIdAsync(TicketStatusId id);
    Task<TicketStatus?> GetByNameAsync(TicketStatusName name);
    Task AddAsync(TicketStatus ticketStatus);
    Task UpdateAsync(TicketStatus ticketStatus);
    Task DeleteAsync(TicketStatus ticketStatus);
    Task<bool> ExistsAsync(TicketStatusId id);
}
