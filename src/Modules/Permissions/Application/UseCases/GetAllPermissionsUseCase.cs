using GestionAerolineas.src.Modules.Permissions.Domain.Aggregate;
using GestionAerolineas.src.Modules.Permissions.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Permissions.Application.UseCases;

public class GetAllPermissionsUseCase
{
    private readonly IPermissionRepository _repository;

    public GetAllPermissionsUseCase(IPermissionRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Permission>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}
