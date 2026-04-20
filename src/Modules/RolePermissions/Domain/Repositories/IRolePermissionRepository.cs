using GestionAerolineas.src.Modules.RolePermissions.Domain.Aggregate;
using GestionAerolineas.src.Modules.RolePermissions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.RolePermissions.Domain.Repositories;

public interface IRolePermissionRepository
{
    Task<IEnumerable<RolePermission>> GetAllAsync();
    Task<RolePermission?> GetByIdAsync(RolePermissionId id);
    Task<RolePermission?> GetByPairAsync(SystemRoleId roleId, PermissionId permissionId);
    Task AddAsync(RolePermission rolePermission);
    Task UpdateAsync(RolePermission rolePermission);
    Task DeleteAsync(RolePermission rolePermission);
    Task<bool> ExistsAsync(RolePermissionId id);
}

