using GestionAerolineas.src.Modules.ReservationPassengers.Domain.Aggregate;
using GestionAerolineas.src.Modules.ReservationPassengers.Domain.Repositories;
using GestionAerolineas.src.Modules.ReservationPassengers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.ReservationPassengers.Application.UseCases;

public class GetReservationPassengersByReservationFlightIdUseCase
{
    private readonly IReservationPassengerRepository _repository;

    public GetReservationPassengersByReservationFlightIdUseCase(IReservationPassengerRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<ReservationPassenger>> ExecuteAsync(int reservationFlightId)
    {
        return _repository.GetByReservationFlightIdAsync(ReservationPassengerReservationFlightId.Create(reservationFlightId));
    }
}

