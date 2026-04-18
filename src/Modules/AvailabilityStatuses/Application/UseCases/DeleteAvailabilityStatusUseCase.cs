using GestionAerolineas.src.Modules.AvailabilityStatuses.Domain.Repositories;
using GestionAerolineas.src.Modules.AvailabilityStatuses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.AvailabilityStatuses.Application.UseCases;

public class DeleteAvailabilityStatusUseCase
{
    private readonly IAvailabilityStatusRepository _repository;

    public DeleteAvailabilityStatusUseCase(IAvailabilityStatusRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var availabilityStatusId = AvailabilityStatusId.Create(id);
        var availabilityStatus = await _repository.GetByIdAsync(availabilityStatusId);

        if (availabilityStatus is null)
            throw new KeyNotFoundException($"AvailabilityStatus con id '{availabilityStatusId.Value}' no existe.");

        await _repository.DeleteAsync(availabilityStatus);
    }
}
