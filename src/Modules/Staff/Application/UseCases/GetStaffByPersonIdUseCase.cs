using GestionAerolineas.src.Modules.Staff.Domain.Aggregate;
using GestionAerolineas.src.Modules.Staff.Domain.Repositories;
using GestionAerolineas.src.Modules.Staff.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Staff.Application.UseCases;

public class GetStaffByPersonIdUseCase
{
    private readonly IStaffRepository _repository;

    public GetStaffByPersonIdUseCase(IStaffRepository repository)
    {
        _repository = repository;
    }

    public Task<StaffMember?> ExecuteAsync(int personId)
    {
        return _repository.GetByPersonIdAsync(StaffPersonId.Create(personId));
    }
}

