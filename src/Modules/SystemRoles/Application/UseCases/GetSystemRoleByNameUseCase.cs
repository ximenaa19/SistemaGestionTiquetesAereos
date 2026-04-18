using GestionAerolineas.src.Modules.SystemRoles.Domain.Aggregate;
using GestionAerolineas.src.Modules.SystemRoles.Domain.Repositories;
using GestionAerolineas.src.Modules.SystemRoles.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.SystemRoles.Application.UseCases;

public class GetSystemRoleByNameUseCase
{
    private readonly ISystemRoleRepository _repository;

    public GetSystemRoleByNameUseCase(ISystemRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<SystemRole?> ExecuteAsync(string name)
    {
        var nameVO = SystemRoleName.Create(name);
        return await _repository.GetByNameAsync(nameVO);
    }
}
