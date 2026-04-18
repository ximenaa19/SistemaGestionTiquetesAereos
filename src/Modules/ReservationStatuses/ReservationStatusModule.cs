using GestionAerolineas.src.Modules.ReservationStatuses.Application.Interfaces;
using GestionAerolineas.src.Modules.ReservationStatuses.Application.Services;
using GestionAerolineas.src.Modules.ReservationStatuses.Application.UseCases;
using GestionAerolineas.src.Modules.ReservationStatuses.Infrastructure.Repository;
using GestionAerolineas.src.Modules.ReservationStatuses.UI;
using GestionAerolineas.src.shared.Context;

namespace GestionAerolineas.src.Modules.ReservationStatuses;

public static class ReservationStatusModule
{
    public static ReservationStatusMenu Build(AppDbContext context)
    {
        var repository = new ReservationStatusRepository(context);
        IReservationStatusValidator validator = new ReservationStatusValidator(repository);

        var create = new CreateReservationStatusUseCase(repository, validator);
        var getAll = new GetAllReservationStatusesUseCase(repository);
        var getById = new GetReservationStatusByIdUseCase(repository);
        var getByName = new GetReservationStatusByNameUseCase(repository);
        var update = new UpdateReservationStatusUseCase(repository, validator);
        var delete = new DeleteReservationStatusUseCase(repository);

        return new ReservationStatusMenu(
            create,
            getAll,
            getById,
            getByName,
            update,
            delete
        );
    }
}

