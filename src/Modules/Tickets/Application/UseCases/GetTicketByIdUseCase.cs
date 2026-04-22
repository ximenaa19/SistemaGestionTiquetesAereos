using GestionAerolineas.src.Modules.Tickets.Domain.Aggregate;
using GestionAerolineas.src.Modules.Tickets.Domain.Repositories;
using GestionAerolineas.src.Modules.Tickets.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Tickets.Application.UseCases;

public class GetTicketByIdUseCase
{
    private readonly ITicketRepository _repository;

    public GetTicketByIdUseCase(ITicketRepository repository)
    {
        _repository = repository;
    }

    public Task<Ticket?> ExecuteAsync(int id)
    {
        return _repository.GetByIdAsync(TicketId.Create(id));
    }
}

