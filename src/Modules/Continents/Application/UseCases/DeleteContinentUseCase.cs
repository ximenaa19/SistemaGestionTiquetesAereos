using GestionAerolineas.src.Modules.Continents.Domain.Repositories;
using GestionAerolineas.src.Modules.Continents.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Continents.Application.UseCases;

public class DeleteContinentUseCase
{
    private readonly IContinentRepository _repository;

    public DeleteContinentUseCase(IContinentRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var continentId = ContinentId.Create(id);
        var continent = await _repository.GetByIdAsync(continentId);

        if (continent is null)
        {
            throw new KeyNotFoundException($"Continent con id '{continentId.Value}' no existe.");
        }

        await _repository.DeleteAsync(continent);
    }
}
