using GestionAerolineas.src.Modules.StaffRoles.Domain.Aggregate;
using GestionAerolineas.src.Modules.StaffRoles.Domain.Repositories;
using GestionAerolineas.src.Modules.StaffRoles.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.StaffRoles.Application.UseCases;

public class GetStaffRoleByNameUseCase
{
    private readonly IStaffRoleRepository _repository;

    public GetStaffRoleByNameUseCase(IStaffRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<StaffRole?> ExecuteAsync(string name)
    {
        var nameVO = StaffRoleName.Create(name);
        return await _repository.GetByNameAsync(nameVO);
    }
}
