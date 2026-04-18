using GestionAerolineas.src.Modules.AvailabilityStatuses.Domain.Aggregate;
using GestionAerolineas.src.Modules.AvailabilityStatuses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.AvailabilityStatuses.Domain.Repositories;

public interface IAvailabilityStatusRepository
{
    Task<IEnumerable<AvailabilityStatus>> GetAllAsync();
    Task<AvailabilityStatus?> GetByIdAsync(AvailabilityStatusId id);
    Task<AvailabilityStatus?> GetByNameAsync(AvailabilityStatusName name);
    Task AddAsync(AvailabilityStatus availabilityStatus);
    Task UpdateAsync(AvailabilityStatus availabilityStatus);
    Task DeleteAsync(AvailabilityStatus availabilityStatus);
    Task<bool> ExistsAsync(AvailabilityStatusId id);
}
