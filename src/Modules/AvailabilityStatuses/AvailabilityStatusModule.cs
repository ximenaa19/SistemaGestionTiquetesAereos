using GestionAerolineas.src.Modules.AvailabilityStatuses.Application.Interfaces;
using GestionAerolineas.src.Modules.AvailabilityStatuses.Application.Services;
using GestionAerolineas.src.Modules.AvailabilityStatuses.Application.UseCases;
using GestionAerolineas.src.Modules.AvailabilityStatuses.Infrastructure.Repository;
using GestionAerolineas.src.Modules.AvailabilityStatuses.UI;
using GestionAerolineas.src.shared.Context;

namespace GestionAerolineas.src.Modules.AvailabilityStatuses;

public static class AvailabilityStatusModule
{
    public static AvailabilityStatusMenu Build(AppDbContext context)
    {
        var repository = new AvailabilityStatusRepository(context);
        IAvailabilityStatusValidator validator = new AvailabilityStatusValidator(repository);

        var create = new CreateAvailabilityStatusUseCase(repository, validator);
        var getAll = new GetAllAvailabilityStatusesUseCase(repository);
        var getById = new GetAvailabilityStatusByIdUseCase(repository);
        var getByName = new GetAvailabilityStatusByNameUseCase(repository);
        var update = new UpdateAvailabilityStatusUseCase(repository, validator);
        var delete = new DeleteAvailabilityStatusUseCase(repository);

        return new AvailabilityStatusMenu(
            create,
            getAll,
            getById,
            getByName,
            update,
            delete
        );
    }
}
