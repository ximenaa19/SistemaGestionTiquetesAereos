using GestionAerolineas.src.Modules.Tickets.Domain.Aggregate;
using GestionAerolineas.src.Modules.Tickets.Domain.Repositories;
using GestionAerolineas.src.Modules.Tickets.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Tickets.Application.UseCases;

public class GetTicketsByStatusIdUseCase
{
    private readonly ITicketRepository _repository;

    public GetTicketsByStatusIdUseCase(ITicketRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Ticket>> ExecuteAsync(int statusId)
    {
        return _repository.GetByStatusIdAsync(TicketStatusId.Create(statusId));
    }
}

