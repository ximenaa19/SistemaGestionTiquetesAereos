using GestionAerolineas.src.Modules.StaffAvailability.Domain.Aggregate;
using GestionAerolineas.src.Modules.StaffAvailability.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.StaffAvailability.Domain.Repositories;

public interface IStaffAvailabilityRepository
{
    Task<IEnumerable<StaffAvailabilityBlock>> GetAllAsync();
    Task<StaffAvailabilityBlock?> GetByIdAsync(StaffAvailabilityId id);
    Task<IEnumerable<StaffAvailabilityBlock>> GetByStaffIdAsync(StaffAvailabilityStaffId staffId);
    Task<IEnumerable<StaffAvailabilityBlock>> GetByStatusIdAsync(StaffAvailabilityStatusId statusId);
    Task<StaffAvailabilityBlock?> GetActiveNowByStaffIdAsync(StaffAvailabilityStaffId staffId, DateTime now);
    Task AddAsync(StaffAvailabilityBlock block);
    Task UpdateAsync(StaffAvailabilityBlock block);
    Task DeleteAsync(StaffAvailabilityBlock block);
    Task<bool> ExistsAsync(StaffAvailabilityId id);
    Task<bool> ExistsOverlapAsync(int staffId, DateTime start, DateTime end, int? excludingId = null);
}
