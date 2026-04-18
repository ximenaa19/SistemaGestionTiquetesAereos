using GestionAerolineas.src.Modules.Seasons.Application.Interfaces;
using GestionAerolineas.src.Modules.Seasons.Application.Services;
using GestionAerolineas.src.Modules.Seasons.Application.UseCases;
using GestionAerolineas.src.Modules.Seasons.Infrastructure.Repository;
using GestionAerolineas.src.Modules.Seasons.UI;
using GestionAerolineas.src.shared.Context;

namespace GestionAerolineas.src.Modules.Seasons;

public static class SeasonModule
{
    public static SeasonMenu Build(AppDbContext context)
    {
        var repository = new SeasonRepository(context);
        ISeasonValidator validator = new SeasonValidator(repository);

        var create = new CreateSeasonUseCase(repository, validator);
        var getAll = new GetAllSeasonsUseCase(repository);
        var getById = new GetSeasonByIdUseCase(repository);
        var getByName = new GetSeasonByNameUseCase(repository);
        var update = new UpdateSeasonUseCase(repository, validator);
        var delete = new DeleteSeasonUseCase(repository);

        return new SeasonMenu(
            create,
            getAll,
            getById,
            getByName,
            update,
            delete
        );
    }
}
