using GestionAerolineas.src.Modules.RolePermissions.Domain.Aggregate;
using GestionAerolineas.src.Modules.RolePermissions.Domain.Repositories;

namespace GestionAerolineas.src.Modules.RolePermissions.Application.UseCases;

public class GetAllRolePermissionsUseCase
{
    private readonly IRolePermissionRepository _repository;

    public GetAllRolePermissionsUseCase(IRolePermissionRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<RolePermission>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}

