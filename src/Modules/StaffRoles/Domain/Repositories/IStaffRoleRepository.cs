using GestionAerolineas.src.Modules.StaffRoles.Domain.Aggregate;
using GestionAerolineas.src.Modules.StaffRoles.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.StaffRoles.Domain.Repositories;

public interface IStaffRoleRepository
{
    Task<IEnumerable<StaffRole>> GetAllAsync();
    Task<StaffRole?> GetByIdAsync(StaffRoleId id);
    Task<StaffRole?> GetByNameAsync(StaffRoleName name);
    Task AddAsync(StaffRole staffRole);
    Task UpdateAsync(StaffRole staffRole);
    Task DeleteAsync(StaffRole staffRole);
    Task<bool> ExistsAsync(StaffRoleId id);
}
