using GestionAerolineas.src.Modules.Tickets.Domain.Aggregate;
using GestionAerolineas.src.Modules.Tickets.Domain.Repositories;
using GestionAerolineas.src.Modules.Tickets.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Tickets.Application.UseCases;

public class GetTicketByReservationPassengerIdUseCase
{
    private readonly ITicketRepository _repository;

    public GetTicketByReservationPassengerIdUseCase(ITicketRepository repository)
    {
        _repository = repository;
    }

    public Task<Ticket?> ExecuteAsync(int reservationPassengerId)
    {
        return _repository.GetByReservationPassengerIdAsync(TicketReservationPassengerId.Create(reservationPassengerId));
    }
}

