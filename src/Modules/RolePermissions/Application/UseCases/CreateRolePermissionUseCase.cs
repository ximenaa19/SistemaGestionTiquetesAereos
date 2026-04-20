using GestionAerolineas.src.Modules.RolePermissions.Application.Interfaces;
using GestionAerolineas.src.Modules.RolePermissions.Domain.Aggregate;
using GestionAerolineas.src.Modules.RolePermissions.Domain.Repositories;
using GestionAerolineas.src.Modules.RolePermissions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.RolePermissions.Application.UseCases;

public class CreateRolePermissionUseCase
{
    private readonly IRolePermissionRepository _repository;
    private readonly IRolePermissionValidator _validator;

    public CreateRolePermissionUseCase(IRolePermissionRepository repository, IRolePermissionValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(int roleId, int permissionId)
    {
        var roleIdVO = SystemRoleId.Create(roleId);
        var permissionIdVO = PermissionId.Create(permissionId);

        await _validator.ValidatePairAsync(roleIdVO, permissionIdVO);

        var entity = RolePermission.CreateNew(roleIdVO, permissionIdVO);

        await _repository.AddAsync(entity);
    }
}

