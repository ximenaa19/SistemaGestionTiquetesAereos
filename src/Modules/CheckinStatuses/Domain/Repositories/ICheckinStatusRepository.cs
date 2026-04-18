using GestionAerolineas.src.Modules.CheckinStatuses.Domain.Aggregate;
using GestionAerolineas.src.Modules.CheckinStatuses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CheckinStatuses.Domain.Repositories;

public interface ICheckinStatusRepository
{
    Task<IEnumerable<CheckinStatus>> GetAllAsync();
    Task<CheckinStatus?> GetByIdAsync(CheckinStatusId id);
    Task<CheckinStatus?> GetByNameAsync(CheckinStatusName name);
    Task AddAsync(CheckinStatus checkinStatus);
    Task UpdateAsync(CheckinStatus checkinStatus);
    Task DeleteAsync(CheckinStatus checkinStatus);
    Task<bool> ExistsAsync(CheckinStatusId id);
}
