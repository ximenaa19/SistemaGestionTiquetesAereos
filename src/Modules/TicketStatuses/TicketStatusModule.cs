using GestionAerolineas.src.Modules.TicketStatuses.Application.Interfaces;
using GestionAerolineas.src.Modules.TicketStatuses.Application.Services;
using GestionAerolineas.src.Modules.TicketStatuses.Application.UseCases;
using GestionAerolineas.src.Modules.TicketStatuses.Infrastructure.Repository;
using GestionAerolineas.src.Modules.TicketStatuses.UI;
using GestionAerolineas.src.shared.Context;

namespace GestionAerolineas.src.Modules.TicketStatuses;

public static class TicketStatusModule
{
    public static TicketStatusMenu Build(AppDbContext context)
    {
        var repository = new TicketStatusRepository(context);
        ITicketStatusValidator validator = new TicketStatusValidator(repository);

        var create = new CreateTicketStatusUseCase(repository, validator);
        var getAll = new GetAllTicketStatusesUseCase(repository);
        var getById = new GetTicketStatusByIdUseCase(repository);
        var getByName = new GetTicketStatusByNameUseCase(repository);
        var update = new UpdateTicketStatusUseCase(repository, validator);
        var delete = new DeleteTicketStatusUseCase(repository);

        return new TicketStatusMenu(
            create,
            getAll,
            getById,
            getByName,
            update,
            delete
        );
    }
}
