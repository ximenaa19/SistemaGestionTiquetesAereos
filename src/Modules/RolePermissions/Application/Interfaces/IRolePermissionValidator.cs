using GestionAerolineas.src.Modules.RolePermissions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.RolePermissions.Application.Interfaces;

public interface IRolePermissionValidator
{
    Task ValidatePairAsync(SystemRoleId roleId, PermissionId permissionId, RolePermissionId? currentId = null);
}

