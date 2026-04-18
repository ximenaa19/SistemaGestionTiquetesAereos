using GestionAerolineas.src.Modules.SystemRoles.Domain.Repositories;
using GestionAerolineas.src.Modules.SystemRoles.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.SystemRoles.Application.UseCases;

public class DeleteSystemRoleUseCase
{
    private readonly ISystemRoleRepository _repository;

    public DeleteSystemRoleUseCase(ISystemRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var systemRoleId = SystemRoleId.Create(id);
        var systemRole = await _repository.GetByIdAsync(systemRoleId);

        if (systemRole is null)
            throw new KeyNotFoundException($"SystemRole con id '{systemRoleId.Value}' no existe.");

        await _repository.DeleteAsync(systemRole);
    }
}
