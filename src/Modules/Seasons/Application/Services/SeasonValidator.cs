using GestionAerolineas.src.Modules.Seasons.Application.Interfaces;
using GestionAerolineas.src.Modules.Seasons.Domain.Repositories;
using GestionAerolineas.src.Modules.Seasons.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Seasons.Application.Services;

public class SeasonValidator : ISeasonValidator
{
    private readonly ISeasonRepository _repository;

    public SeasonValidator(ISeasonRepository repository)
    {
        _repository = repository;
    }

    public async Task ValidateNameAsync(SeasonName name, SeasonId? currentId = null)
    {
        var existingByName = await _repository.GetByNameAsync(name);

        if (existingByName is not null && existingByName.Id != currentId)
            throw new Exception("Ya existe una temporada con ese nombre");
    }
}
