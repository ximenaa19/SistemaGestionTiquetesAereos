using GestionAerolineas.src.Modules.Staff.Domain.Aggregate;
using GestionAerolineas.src.Modules.Staff.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Staff.Domain.Repositories;

public interface IStaffRepository
{
    Task<IEnumerable<StaffMember>> GetAllAsync();
    Task<StaffMember?> GetByIdAsync(StaffId id);
    Task<StaffMember?> GetByPersonIdAsync(StaffPersonId personId);
    Task<IEnumerable<StaffMember>> GetByRoleIdAsync(StaffRoleId roleId);
    Task<IEnumerable<StaffMember>> GetByIsActiveAsync(StaffIsActive isActive);
    Task<IEnumerable<StaffMember>> SearchByPersonNameOrLastNameAsync(string searchText);
    Task AddAsync(StaffMember staff);
    Task UpdateAsync(StaffMember staff);
    Task DeleteAsync(StaffMember staff);
    Task<bool> ExistsAsync(StaffId id);
    Task<bool> ExistsByPersonIdAsync(int personId, int? excludingId = null);
}

