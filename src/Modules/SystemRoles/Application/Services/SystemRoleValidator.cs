using GestionAerolineas.src.Modules.SystemRoles.Application.Interfaces;
using GestionAerolineas.src.Modules.SystemRoles.Domain.Repositories;
using GestionAerolineas.src.Modules.SystemRoles.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.SystemRoles.Application.Services;

public class SystemRoleValidator : ISystemRoleValidator
{
    private readonly ISystemRoleRepository _repository;

    public SystemRoleValidator(ISystemRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task ValidateNameAsync(SystemRoleName name, SystemRoleId? currentId = null)
    {
        var existingByName = await _repository.GetByNameAsync(name);

        if (existingByName is not null && existingByName.Id != currentId)
            throw new Exception("Ya existe un rol del sistema con ese nombre");
    }
}
