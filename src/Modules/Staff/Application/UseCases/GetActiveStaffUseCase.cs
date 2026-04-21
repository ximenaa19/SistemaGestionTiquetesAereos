using GestionAerolineas.src.Modules.Staff.Domain.Aggregate;
using GestionAerolineas.src.Modules.Staff.Domain.Repositories;
using GestionAerolineas.src.Modules.Staff.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Staff.Application.UseCases;

public class GetActiveStaffUseCase
{
    private readonly IStaffRepository _repository;

    public GetActiveStaffUseCase(IStaffRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<StaffMember>> ExecuteAsync()
    {
        return _repository.GetByIsActiveAsync(StaffIsActive.Create(true));
    }
}

