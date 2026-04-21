using GestionAerolineas.src.Modules.Staff.Domain.Aggregate;
using GestionAerolineas.src.Modules.Staff.Domain.Repositories;
using GestionAerolineas.src.Modules.Staff.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Staff.Application.UseCases;

public class GetStaffByRoleIdUseCase
{
    private readonly IStaffRepository _repository;

    public GetStaffByRoleIdUseCase(IStaffRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<StaffMember>> ExecuteAsync(int roleId)
    {
        return _repository.GetByRoleIdAsync(StaffRoleId.Create(roleId));
    }
}

