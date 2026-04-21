using GestionAerolineas.src.Modules.StaffAvailability.Domain.Repositories;
using GestionAerolineas.src.Modules.StaffAvailability.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.StaffAvailability.Application.UseCases;

public class DeleteStaffAvailabilityUseCase
{
    private readonly IStaffAvailabilityRepository _repository;

    public DeleteStaffAvailabilityUseCase(IStaffAvailabilityRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(StaffAvailabilityId.Create(id));
        if (entity is null)
            return;

        await _repository.DeleteAsync(entity);
    }
}

