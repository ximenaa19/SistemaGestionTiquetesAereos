using GestionAerolineas.src.Modules.StaffRoles.Application.Interfaces;
using GestionAerolineas.src.Modules.StaffRoles.Domain.Repositories;
using GestionAerolineas.src.Modules.StaffRoles.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.StaffRoles.Application.Services;

public class StaffRoleValidator : IStaffRoleValidator
{
    private readonly IStaffRoleRepository _repository;

    public StaffRoleValidator(IStaffRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task ValidateNameAsync(StaffRoleName name, StaffRoleId? currentId = null)
    {
        var existingByName = await _repository.GetByNameAsync(name);

        if (existingByName is not null && existingByName.Id != currentId)
            throw new Exception("Ya existe un cargo del personal con ese nombre");
    }
}
