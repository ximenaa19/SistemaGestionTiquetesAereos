using GestionAerolineas.src.Modules.Tickets.Domain.Aggregate;
using GestionAerolineas.src.Modules.Tickets.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Tickets.Application.UseCases;

public class GetTicketsByReservationCodeUseCase
{
    private readonly ITicketRepository _repository;

    public GetTicketsByReservationCodeUseCase(ITicketRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Ticket>> ExecuteAsync(string reservationCode)
    {
        return _repository.GetByReservationCodeAsync(reservationCode);
    }
}

