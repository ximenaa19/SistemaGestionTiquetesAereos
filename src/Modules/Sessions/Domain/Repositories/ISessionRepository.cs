using GestionAerolineas.src.Modules.Sessions.Domain.Aggregate;
using GestionAerolineas.src.Modules.Sessions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Sessions.Domain.Repositories;

public interface ISessionRepository
{
    Task<IEnumerable<Session>> GetAllAsync();
    Task<Session?> GetByIdAsync(SessionId id);
    Task<IEnumerable<Session>> GetByUserIdAsync(SessionUserId userId);
    Task<IEnumerable<Session>> GetByIsActiveAsync(SessionIsActive isActive);
    Task<IEnumerable<Session>> GetByDateRangeAsync(DateTime from, DateTime to);
    Task<IEnumerable<Session>> GetActiveByUserIdAsync(SessionUserId userId);
    Task AddAsync(Session session);
    Task UpdateAsync(Session session);
    Task DeleteAsync(Session session);
    Task<bool> ExistsAsync(SessionId id);
}
