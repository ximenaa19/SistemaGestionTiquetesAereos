using GestionAerolineas.src.Modules.StaffAvailability.Domain.Aggregate;
using GestionAerolineas.src.Modules.StaffAvailability.Domain.Repositories;
using GestionAerolineas.src.Modules.StaffAvailability.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.StaffAvailability.Application.UseCases;

public class GetStaffAvailabilityByIdUseCase
{
    private readonly IStaffAvailabilityRepository _repository;

    public GetStaffAvailabilityByIdUseCase(IStaffAvailabilityRepository repository)
    {
        _repository = repository;
    }

    public Task<StaffAvailabilityBlock?> ExecuteAsync(int id)
    {
        return _repository.GetByIdAsync(StaffAvailabilityId.Create(id));
    }
}
