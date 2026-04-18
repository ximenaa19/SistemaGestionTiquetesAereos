using GestionAerolineas.src.Modules.Permissions.Domain.Aggregate;
using GestionAerolineas.src.Modules.Permissions.Domain.Repositories;
using GestionAerolineas.src.Modules.Permissions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Permissions.Application.UseCases;

public class GetPermissionByIdUseCase
{
    private readonly IPermissionRepository _repository;

    public GetPermissionByIdUseCase(IPermissionRepository repository)
    {
        _repository = repository;
    }

    public async Task<Permission?> ExecuteAsync(int id)
    {
        var idVO = PermissionId.Create(id);
        return await _repository.GetByIdAsync(idVO);
    }
}
