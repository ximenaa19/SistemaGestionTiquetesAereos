using GestionAerolineas.src.Modules.Seasons.Domain.Aggregate;
using GestionAerolineas.src.Modules.Seasons.Domain.Repositories;
using GestionAerolineas.src.Modules.Seasons.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Seasons.Application.UseCases;

public class GetSeasonByIdUseCase
{
    private readonly ISeasonRepository _repository;

    public GetSeasonByIdUseCase(ISeasonRepository repository)
    {
        _repository = repository;
    }

    public async Task<Season?> ExecuteAsync(int id)
    {
        var idVO = SeasonId.Create(id);
        return await _repository.GetByIdAsync(idVO);
    }
}
