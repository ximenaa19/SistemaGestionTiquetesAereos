using GestionAerolineas.src.Modules.Continents.Domain.Aggregate;
using GestionAerolineas.src.Modules.Continents.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Continents.Application.UseCases;

public class GetAllContinentUseCase
{
    private readonly IContinentRepository _repository;

    public GetAllContinentUseCase(IContinentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Continent>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}