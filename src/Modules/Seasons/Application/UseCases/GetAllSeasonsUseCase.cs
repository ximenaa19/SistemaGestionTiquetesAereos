using GestionAerolineas.src.Modules.Seasons.Domain.Aggregate;
using GestionAerolineas.src.Modules.Seasons.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Seasons.Application.UseCases;

public class GetAllSeasonsUseCase
{
    private readonly ISeasonRepository _repository;

    public GetAllSeasonsUseCase(ISeasonRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Season>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}
