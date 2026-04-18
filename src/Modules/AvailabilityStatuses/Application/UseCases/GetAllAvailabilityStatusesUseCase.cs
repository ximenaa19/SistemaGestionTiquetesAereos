using GestionAerolineas.src.Modules.AvailabilityStatuses.Domain.Aggregate;
using GestionAerolineas.src.Modules.AvailabilityStatuses.Domain.Repositories;

namespace GestionAerolineas.src.Modules.AvailabilityStatuses.Application.UseCases;

public class GetAllAvailabilityStatusesUseCase
{
    private readonly IAvailabilityStatusRepository _repository;

    public GetAllAvailabilityStatusesUseCase(IAvailabilityStatusRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AvailabilityStatus>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}
