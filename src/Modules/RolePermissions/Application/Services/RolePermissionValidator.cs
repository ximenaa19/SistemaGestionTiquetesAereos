using GestionAerolineas.src.Modules.RolePermissions.Application.Interfaces;
using GestionAerolineas.src.Modules.RolePermissions.Domain.Repositories;
using GestionAerolineas.src.Modules.RolePermissions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.RolePermissions.Application.Services;

public class RolePermissionValidator : IRolePermissionValidator
{
    private readonly IRolePermissionRepository _repository;

    public RolePermissionValidator(IRolePermissionRepository repository)
    {
        _repository = repository;
    }

    public async Task ValidatePairAsync(SystemRoleId roleId, PermissionId permissionId, RolePermissionId? currentId = null)
    {
        var existing = await _repository.GetByPairAsync(roleId, permissionId);

        if (existing is null)
            return;

        if (currentId != null && existing.Id.Value == currentId.Value)
            return;

        throw new Exception("Ya existe ese permiso asignado a ese rol");
    }
}

