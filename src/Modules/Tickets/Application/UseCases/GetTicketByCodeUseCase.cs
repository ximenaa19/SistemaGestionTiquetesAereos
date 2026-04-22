using GestionAerolineas.src.Modules.Tickets.Domain.Aggregate;
using GestionAerolineas.src.Modules.Tickets.Domain.Repositories;
using GestionAerolineas.src.Modules.Tickets.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Tickets.Application.UseCases;

public class GetTicketByCodeUseCase
{
    private readonly ITicketRepository _repository;

    public GetTicketByCodeUseCase(ITicketRepository repository)
    {
        _repository = repository;
    }

    public Task<Ticket?> ExecuteAsync(string code)
    {
        return _repository.GetByCodeAsync(TicketCode.Create(code));
    }
}

