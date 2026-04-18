using GestionAerolineas.src.Modules.CheckinStatuses.Domain.Aggregate;
using GestionAerolineas.src.Modules.CheckinStatuses.Domain.Repositories;
using GestionAerolineas.src.Modules.CheckinStatuses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CheckinStatuses.Application.UseCases;

public class GetCheckinStatusByIdUseCase
{
    private readonly ICheckinStatusRepository _repository;

    public GetCheckinStatusByIdUseCase(ICheckinStatusRepository repository)
    {
        _repository = repository;
    }

    public async Task<CheckinStatus?> ExecuteAsync(int id)
    {
        var idVO = CheckinStatusId.Create(id);
        return await _repository.GetByIdAsync(idVO);
    }
}
