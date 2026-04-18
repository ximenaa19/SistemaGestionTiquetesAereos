using GestionAerolineas.src.Modules.StaffRoles.Domain.Aggregate;
using GestionAerolineas.src.Modules.StaffRoles.Domain.Repositories;
using GestionAerolineas.src.Modules.StaffRoles.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.StaffRoles.Application.UseCases;

public class GetStaffRoleByIdUseCase
{
    private readonly IStaffRoleRepository _repository;

    public GetStaffRoleByIdUseCase(IStaffRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<StaffRole?> ExecuteAsync(int id)
    {
        var idVO = StaffRoleId.Create(id);
        return await _repository.GetByIdAsync(idVO);
    }
}
