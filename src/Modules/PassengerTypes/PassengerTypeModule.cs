using GestionAerolineas.src.Modules.PassengerTypes.Application.Interfaces;
using GestionAerolineas.src.Modules.PassengerTypes.Application.Services;
using GestionAerolineas.src.Modules.PassengerTypes.Application.UseCases;
using GestionAerolineas.src.Modules.PassengerTypes.Infrastructure.Repository;
using GestionAerolineas.src.Modules.PassengerTypes.UI;
using GestionAerolineas.src.shared.Context;

namespace GestionAerolineas.src.Modules.PassengerTypes;

public static class PassengerTypeModule
{
    public static PassengerTypeMenu Build(AppDbContext context)
    {
        var repository = new PassengerTypeRepository(context);
        IPassengerTypeValidator validator = new PassengerTypeValidator(repository);

        var create = new CreatePassengerTypeUseCase(repository, validator);
        var getAll = new GetAllPassengerTypesUseCase(repository);
        var getById = new GetPassengerTypeByIdUseCase(repository);
        var getByName = new GetPassengerTypeByNameUseCase(repository);
        var update = new UpdatePassengerTypeUseCase(repository, validator);
        var delete = new DeletePassengerTypeUseCase(repository);

        return new PassengerTypeMenu(
            create,
            getAll,
            getById,
            getByName,
            update,
            delete
        );
    }
}

