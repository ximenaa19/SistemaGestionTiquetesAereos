using GestionAerolineas.src.Modules.StaffAvailability.Domain.Aggregate;
using GestionAerolineas.src.Modules.StaffAvailability.Domain.Repositories;

namespace GestionAerolineas.src.Modules.StaffAvailability.Application.UseCases;

public class GetAllStaffAvailabilityUseCase
{
    private readonly IStaffAvailabilityRepository _repository;

    public GetAllStaffAvailabilityUseCase(IStaffAvailabilityRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<StaffAvailabilityBlock>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}
