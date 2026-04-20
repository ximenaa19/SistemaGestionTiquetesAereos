using GestionAerolineas.src.Modules.RolePermissions.Application.Interfaces;
using GestionAerolineas.src.Modules.RolePermissions.Domain.Aggregate;
using GestionAerolineas.src.Modules.RolePermissions.Domain.Repositories;
using GestionAerolineas.src.Modules.RolePermissions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.RolePermissions.Application.UseCases;

public class UpdateRolePermissionUseCase
{
    private readonly IRolePermissionRepository _repository;
    private readonly IRolePermissionValidator _validator;

    public UpdateRolePermissionUseCase(IRolePermissionRepository repository, IRolePermissionValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(int id, int roleId, int permissionId)
    {
        var idVO = RolePermissionId.Create(id);

        var existing = await _repository.GetByIdAsync(idVO);

        if (existing is null)
            throw new Exception("La asignación no existe");

        var roleIdVO = SystemRoleId.Create(roleId);
        var permissionIdVO = PermissionId.Create(permissionId);

        await _validator.ValidatePairAsync(roleIdVO, permissionIdVO, idVO);

        var updated = RolePermission.Create(idVO, roleIdVO, permissionIdVO);

        await _repository.UpdateAsync(updated);
    }
}

