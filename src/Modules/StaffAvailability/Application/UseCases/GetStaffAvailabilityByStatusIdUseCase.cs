using GestionAerolineas.src.Modules.StaffAvailability.Domain.Aggregate;
using GestionAerolineas.src.Modules.StaffAvailability.Domain.Repositories;
using GestionAerolineas.src.Modules.StaffAvailability.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.StaffAvailability.Application.UseCases;

public class GetStaffAvailabilityByStatusIdUseCase
{
    private readonly IStaffAvailabilityRepository _repository;

    public GetStaffAvailabilityByStatusIdUseCase(IStaffAvailabilityRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<StaffAvailabilityBlock>> ExecuteAsync(int statusId)
    {
        return _repository.GetByStatusIdAsync(StaffAvailabilityStatusId.Create(statusId));
    }
}
