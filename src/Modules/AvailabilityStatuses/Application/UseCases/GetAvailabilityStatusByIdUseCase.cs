using GestionAerolineas.src.Modules.AvailabilityStatuses.Domain.Aggregate;
using GestionAerolineas.src.Modules.AvailabilityStatuses.Domain.Repositories;
using GestionAerolineas.src.Modules.AvailabilityStatuses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.AvailabilityStatuses.Application.UseCases;

public class GetAvailabilityStatusByIdUseCase
{
    private readonly IAvailabilityStatusRepository _repository;

    public GetAvailabilityStatusByIdUseCase(IAvailabilityStatusRepository repository)
    {
        _repository = repository;
    }

    public async Task<AvailabilityStatus?> ExecuteAsync(int id)
    {
        var idVO = AvailabilityStatusId.Create(id);
        return await _repository.GetByIdAsync(idVO);
    }
}
