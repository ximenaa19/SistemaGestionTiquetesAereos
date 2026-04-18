using GestionAerolineas.src.Modules.StaffRoles.Application.Interfaces;
using GestionAerolineas.src.Modules.StaffRoles.Domain.Aggregate;
using GestionAerolineas.src.Modules.StaffRoles.Domain.Repositories;
using GestionAerolineas.src.Modules.StaffRoles.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.StaffRoles.Application.UseCases;

public class CreateStaffRoleUseCase
{
    private readonly IStaffRoleRepository _repository;
    private readonly IStaffRoleValidator _validator;

    public CreateStaffRoleUseCase(
        IStaffRoleRepository repository,
        IStaffRoleValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(string name)
    {
        var nameVO = StaffRoleName.Create(name);

        await _validator.ValidateNameAsync(nameVO);

        var entity = StaffRole.CreateNew(nameVO);

        await _repository.AddAsync(entity);
    }
}
