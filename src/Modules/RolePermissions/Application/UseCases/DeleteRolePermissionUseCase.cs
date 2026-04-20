using GestionAerolineas.src.Modules.RolePermissions.Domain.Repositories;
using GestionAerolineas.src.Modules.RolePermissions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.RolePermissions.Application.UseCases;

public class DeleteRolePermissionUseCase
{
    private readonly IRolePermissionRepository _repository;

    public DeleteRolePermissionUseCase(IRolePermissionRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var idVO = RolePermissionId.Create(id);

        var existing = await _repository.GetByIdAsync(idVO);

        if (existing is null)
            throw new Exception("La asignación no existe");

        await _repository.DeleteAsync(existing);
    }
}

