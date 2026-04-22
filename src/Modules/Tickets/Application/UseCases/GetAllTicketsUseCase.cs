using GestionAerolineas.src.Modules.Tickets.Domain.Aggregate;
using GestionAerolineas.src.Modules.Tickets.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Tickets.Application.UseCases;

public class GetAllTicketsUseCase
{
    private readonly ITicketRepository _repository;

    public GetAllTicketsUseCase(ITicketRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Ticket>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}

