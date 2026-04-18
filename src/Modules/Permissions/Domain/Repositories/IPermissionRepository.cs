using GestionAerolineas.src.Modules.Permissions.Domain.Aggregate;
using GestionAerolineas.src.Modules.Permissions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Permissions.Domain.Repositories;

public interface IPermissionRepository
{
    Task<IEnumerable<Permission>> GetAllAsync();
    Task<Permission?> GetByIdAsync(PermissionId id);
    Task<Permission?> GetByNameAsync(PermissionName name);
    Task AddAsync(Permission permission);
    Task UpdateAsync(Permission permission);
    Task DeleteAsync(Permission permission);
    Task<bool> ExistsAsync(PermissionId id);
}
