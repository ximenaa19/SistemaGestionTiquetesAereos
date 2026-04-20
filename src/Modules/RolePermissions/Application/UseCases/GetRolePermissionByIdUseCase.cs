using GestionAerolineas.src.Modules.RolePermissions.Domain.Aggregate;
using GestionAerolineas.src.Modules.RolePermissions.Domain.Repositories;
using GestionAerolineas.src.Modules.RolePermissions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.RolePermissions.Application.UseCases;

public class GetRolePermissionByIdUseCase
{
    private readonly IRolePermissionRepository _repository;

    public GetRolePermissionByIdUseCase(IRolePermissionRepository repository)
    {
        _repository = repository;
    }

    public Task<RolePermission?> ExecuteAsync(int id)
    {
        var idVO = RolePermissionId.Create(id);
        return _repository.GetByIdAsync(idVO);
    }
}

