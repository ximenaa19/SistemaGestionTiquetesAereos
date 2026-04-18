using GestionAerolineas.src.Modules.SystemRoles.Domain.Aggregate;
using GestionAerolineas.src.Modules.SystemRoles.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.SystemRoles.Domain.Repositories;

public interface ISystemRoleRepository
{
    Task<IEnumerable<SystemRole>> GetAllAsync();
    Task<SystemRole?> GetByIdAsync(SystemRoleId id);
    Task<SystemRole?> GetByNameAsync(SystemRoleName name);
    Task AddAsync(SystemRole systemRole);
    Task UpdateAsync(SystemRole systemRole);
    Task DeleteAsync(SystemRole systemRole);
    Task<bool> ExistsAsync(SystemRoleId id);
}
