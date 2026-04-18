using GestionAerolineas.src.Modules.Continents.Application.Interfaces;
using GestionAerolineas.src.Modules.Continents.Domain.Repositories;
using GestionAerolineas.src.Modules.Continents.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Continents.Application.Services;

public class ContinentValidator : IContinentValidator
{
    private readonly IContinentRepository _repository;

    public ContinentValidator(IContinentRepository repository)
    {
        _repository = repository;
    }

    public async Task ValidateNameAsync(ContinentName name)
    {
        var existing = await _repository.GetByNameAsync(name);

        if (existing != null)
            throw new Exception("Ya existe un continente con ese nombre");
    }
}
