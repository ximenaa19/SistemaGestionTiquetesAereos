using GestionAerolineas.src.Modules.Staff.Domain.Aggregate;
using GestionAerolineas.src.Modules.Staff.Domain.Repositories;
using GestionAerolineas.src.Modules.Staff.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Staff.Application.UseCases;

public class GetStaffByIdUseCase
{
    private readonly IStaffRepository _repository;

    public GetStaffByIdUseCase(IStaffRepository repository)
    {
        _repository = repository;
    }

    public Task<StaffMember?> ExecuteAsync(int id)
    {
        return _repository.GetByIdAsync(StaffId.Create(id));
    }
}

