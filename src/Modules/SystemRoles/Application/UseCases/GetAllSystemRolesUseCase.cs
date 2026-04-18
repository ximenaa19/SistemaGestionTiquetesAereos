using GestionAerolineas.src.Modules.SystemRoles.Domain.Aggregate;
using GestionAerolineas.src.Modules.SystemRoles.Domain.Repositories;

namespace GestionAerolineas.src.Modules.SystemRoles.Application.UseCases;

public class GetAllSystemRolesUseCase
{
    private readonly ISystemRoleRepository _repository;

    public GetAllSystemRolesUseCase(ISystemRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<SystemRole>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}
