using GestionAerolineas.src.Modules.Staff.Domain.Aggregate;
using GestionAerolineas.src.Modules.Staff.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Staff.Application.UseCases;

public class GetAllStaffUseCase
{
    private readonly IStaffRepository _repository;

    public GetAllStaffUseCase(IStaffRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<StaffMember>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}

