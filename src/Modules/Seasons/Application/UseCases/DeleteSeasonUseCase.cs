using GestionAerolineas.src.Modules.Seasons.Domain.Repositories;
using GestionAerolineas.src.Modules.Seasons.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Seasons.Application.UseCases;

public class DeleteSeasonUseCase
{
    private readonly ISeasonRepository _repository;

    public DeleteSeasonUseCase(ISeasonRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var seasonId = SeasonId.Create(id);
        var season = await _repository.GetByIdAsync(seasonId);

        if (season is null)
            throw new KeyNotFoundException($"Season con id '{seasonId.Value}' no existe.");

        await _repository.DeleteAsync(season);
    }
}
