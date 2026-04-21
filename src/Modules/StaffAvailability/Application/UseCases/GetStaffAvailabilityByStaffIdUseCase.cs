using GestionAerolineas.src.Modules.StaffAvailability.Domain.Aggregate;
using GestionAerolineas.src.Modules.StaffAvailability.Domain.Repositories;
using GestionAerolineas.src.Modules.StaffAvailability.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.StaffAvailability.Application.UseCases;

public class GetStaffAvailabilityByStaffIdUseCase
{
    private readonly IStaffAvailabilityRepository _repository;

    public GetStaffAvailabilityByStaffIdUseCase(IStaffAvailabilityRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<StaffAvailabilityBlock>> ExecuteAsync(int staffId)
    {
        return _repository.GetByStaffIdAsync(StaffAvailabilityStaffId.Create(staffId));
    }
}
