using GestionAerolineas.src.Modules.AvailabilityStatuses.Domain.Aggregate;
using GestionAerolineas.src.Modules.AvailabilityStatuses.Domain.Repositories;
using GestionAerolineas.src.Modules.AvailabilityStatuses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.AvailabilityStatuses.Application.UseCases;

public class GetAvailabilityStatusByNameUseCase
{
    private readonly IAvailabilityStatusRepository _repository;

    public GetAvailabilityStatusByNameUseCase(IAvailabilityStatusRepository repository)
    {
        _repository = repository;
    }

    public async Task<AvailabilityStatus?> ExecuteAsync(string name)
    {
        var nameVO = AvailabilityStatusName.Create(name);
        return await _repository.GetByNameAsync(nameVO);
    }
}
