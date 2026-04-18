using GestionAerolineas.src.Modules.StaffRoles.Domain.Aggregate;
using GestionAerolineas.src.Modules.StaffRoles.Domain.Repositories;

namespace GestionAerolineas.src.Modules.StaffRoles.Application.UseCases;

public class GetAllStaffRolesUseCase
{
    private readonly IStaffRoleRepository _repository;

    public GetAllStaffRolesUseCase(IStaffRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<StaffRole>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}
