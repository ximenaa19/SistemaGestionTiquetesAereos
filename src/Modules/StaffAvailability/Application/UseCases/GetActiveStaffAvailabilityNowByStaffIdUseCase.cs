using GestionAerolineas.src.Modules.StaffAvailability.Domain.Aggregate;
using GestionAerolineas.src.Modules.StaffAvailability.Domain.Repositories;
using GestionAerolineas.src.Modules.StaffAvailability.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.StaffAvailability.Application.UseCases;

public class GetActiveStaffAvailabilityNowByStaffIdUseCase
{
    private readonly IStaffAvailabilityRepository _repository;

    public GetActiveStaffAvailabilityNowByStaffIdUseCase(IStaffAvailabilityRepository repository)
    {
        _repository = repository;
    }

    public Task<StaffAvailabilityBlock?> ExecuteAsync(int staffId, DateTime now)
    {
        return _repository.GetActiveNowByStaffIdAsync(StaffAvailabilityStaffId.Create(staffId), now);
    }
}
