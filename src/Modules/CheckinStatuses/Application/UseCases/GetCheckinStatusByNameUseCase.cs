using GestionAerolineas.src.Modules.CheckinStatuses.Domain.Aggregate;
using GestionAerolineas.src.Modules.CheckinStatuses.Domain.Repositories;
using GestionAerolineas.src.Modules.CheckinStatuses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CheckinStatuses.Application.UseCases;

public class GetCheckinStatusByNameUseCase
{
    private readonly ICheckinStatusRepository _repository;

    public GetCheckinStatusByNameUseCase(ICheckinStatusRepository repository)
    {
        _repository = repository;
    }

    public async Task<CheckinStatus?> ExecuteAsync(string name)
    {
        var nameVO = CheckinStatusName.Create(name);
        return await _repository.GetByNameAsync(nameVO);
    }
}
