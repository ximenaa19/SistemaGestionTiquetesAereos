using GestionAerolineas.src.Modules.CheckinStatuses.Domain.Aggregate;
using GestionAerolineas.src.Modules.CheckinStatuses.Domain.Repositories;

namespace GestionAerolineas.src.Modules.CheckinStatuses.Application.UseCases;

public class GetAllCheckinStatusesUseCase
{
    private readonly ICheckinStatusRepository _repository;

    public GetAllCheckinStatusesUseCase(ICheckinStatusRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CheckinStatus>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}
