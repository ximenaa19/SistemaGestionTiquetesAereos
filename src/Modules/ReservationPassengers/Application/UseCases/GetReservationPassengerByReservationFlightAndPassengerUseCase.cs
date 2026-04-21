using GestionAerolineas.src.Modules.ReservationPassengers.Domain.Aggregate;
using GestionAerolineas.src.Modules.ReservationPassengers.Domain.Repositories;
using GestionAerolineas.src.Modules.ReservationPassengers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.ReservationPassengers.Application.UseCases;

public class GetReservationPassengerByReservationFlightAndPassengerUseCase
{
    private readonly IReservationPassengerRepository _repository;

    public GetReservationPassengerByReservationFlightAndPassengerUseCase(IReservationPassengerRepository repository)
    {
        _repository = repository;
    }

    public Task<ReservationPassenger?> ExecuteAsync(int reservationFlightId, int passengerId)
    {
        return _repository.GetByReservationFlightAndPassengerAsync(
            ReservationPassengerReservationFlightId.Create(reservationFlightId),
            ReservationPassengerPassengerId.Create(passengerId));
    }
}

