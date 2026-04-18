using GestionAerolineas.src.Modules.Continents.Application.Interfaces;
using GestionAerolineas.src.Modules.Continents.Domain.Aggregate;
using GestionAerolineas.src.Modules.Continents.Domain.Repositories;
using GestionAerolineas.src.Modules.Continents.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Continents.Application.UseCases;

public class CreateContinentUseCase
{
    private readonly IContinentRepository _repository;
    private readonly IContinentValidator _validator;

    public CreateContinentUseCase(
        IContinentRepository repository,
        IContinentValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(int id, string name)
    {
        var idVO = ContinentId.Create(id);
        var nameVO = ContinentName.Create(name);

        var idExists = await _repository.ExistsAsync(idVO);
        if (idExists)
            throw new Exception("Ya existe un continente con ese ID");

        await _validator.ValidateNameAsync(nameVO);

        var entity = Continent.Create(idVO, nameVO);

        await _repository.AddAsync(entity);
    }
}
