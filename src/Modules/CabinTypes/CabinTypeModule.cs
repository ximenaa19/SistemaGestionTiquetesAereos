using GestionAerolineas.src.Modules.CabinTypes.Application.Interfaces;
using GestionAerolineas.src.Modules.CabinTypes.Application.Services;
using GestionAerolineas.src.Modules.CabinTypes.Application.UseCases;
using GestionAerolineas.src.Modules.CabinTypes.Infrastructure.Repository;
using GestionAerolineas.src.Modules.CabinTypes.UI;
using GestionAerolineas.src.shared.Context;

namespace GestionAerolineas.src.Modules.CabinTypes;

public static class CabinTypeModule
{
    public static CabinTypeMenu Build(AppDbContext context)
    {
        var repository = new CabinTypeRepository(context);
        ICabinTypeValidator validator = new CabinTypeValidator(repository);

        var create = new CreateCabinTypeUseCase(validator, repository);
        var getAll = new GetAllCabinTypeUseCase(repository);
        var getById = new GetCabinTypeByIdUseCase(repository);
        var getByName = new GetCabinTypeByName(repository);
        var update = new UpdateCabinTypeUseCase(repository, validator);
        var delete = new DeleteCabinTypeUseCase(repository);

        return new CabinTypeMenu(
            create,
            getAll,
            getById,
            getByName,
            update,
            delete
        );
    }
}
