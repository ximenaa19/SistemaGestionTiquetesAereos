using GestionAerolineas.src.Modules.Continents.Application.Interfaces;
using GestionAerolineas.src.Modules.Continents.Application.Services;
using GestionAerolineas.src.Modules.Continents.Application.UseCases;
using GestionAerolineas.src.Modules.Continents.Infrastructure.Repository;
using GestionAerolineas.src.Modules.Continents.UI;
using GestionAerolineas.src.shared.Context;

namespace GestionAerolineas.src.Modules.Continents;

public static class ContinentModule
{
    public static ContinentMenu Build(AppDbContext context)
    {
        var repository = new ContinentRepository(context);
        IContinentValidator validator = new ContinentValidator(repository);

        var create = new CreateContinentUseCase(repository, validator);
        var getAll = new GetAllContinentsUseCase(repository);
        var getById = new GetContinentByIdUseCase(repository);
        var getByName = new GetContinentByNameUseCase(repository);
        var update = new UpdateContinentUseCase(repository, validator);
        var delete = new DeleteContinentUseCase(repository);

        return new ContinentMenu(
            create,
            getAll,
            getById,
            getByName,
            update,
            delete
        );
    }
}
