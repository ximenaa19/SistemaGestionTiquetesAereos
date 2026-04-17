using GestionAerolineas.src.Modules.Continents.Domain.Aggregate;
using GestionAerolineas.src.Modules.Continents.Domain.Repositories;
using GestionAerolineas.src.Modules.Continents.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Continents.Application.UseCases;

public class GetContinentByNameUseCase
{
    private readonly IContinentRepository _repository;

    public GetContinentByNameUseCase(IContinentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Continent?> ExecuteAsync(string name)
    {
        var nameVO = ContinentName.Create(name);
        return await _repository.GetByNameAsync(nameVO);
    }
}