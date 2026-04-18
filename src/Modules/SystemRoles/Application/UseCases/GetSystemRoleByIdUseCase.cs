using GestionAerolineas.src.Modules.SystemRoles.Domain.Aggregate;
using GestionAerolineas.src.Modules.SystemRoles.Domain.Repositories;
using GestionAerolineas.src.Modules.SystemRoles.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.SystemRoles.Application.UseCases;

public class GetSystemRoleByIdUseCase
{
    private readonly ISystemRoleRepository _repository;

    public GetSystemRoleByIdUseCase(ISystemRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<SystemRole?> ExecuteAsync(int id)
    {
        var idVO = SystemRoleId.Create(id);
        return await _repository.GetByIdAsync(idVO);
    }
}
