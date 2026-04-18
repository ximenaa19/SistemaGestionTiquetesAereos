using GestionAerolineas.src.Modules.Continents.Application.Interfaces;
using GestionAerolineas.src.Modules.Continents.Domain.Aggregate;
using GestionAerolineas.src.Modules.Continents.Domain.Repositories;
using GestionAerolineas.src.Modules.Continents.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Continents.Application.UseCases;

public class UpdateContinentUseCase
{
    private readonly IContinentRepository _repository;
    private readonly IContinentValidator _validator;

    public UpdateContinentUseCase(
        IContinentRepository repository,
        IContinentValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(int id, string newName)
    {
        var idVO = ContinentId.Create(id);

        var existing = await _repository.GetByIdAsync(idVO);

        if (existing is null)
            throw new Exception("El continente no existe");

        var nameVO = ContinentName.Create(newName);

        await _validator.ValidateNameAsync(nameVO);

        var updated = Continent.Create(idVO, nameVO);

        await _repository.UpdateAsync(updated);
    }
}
