using GestionAerolineas.src.Modules.ReservationPassengers.Domain.Aggregate;
using GestionAerolineas.src.Modules.ReservationPassengers.Domain.Repositories;
using GestionAerolineas.src.Modules.ReservationPassengers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.ReservationPassengers.Application.UseCases;

public class GetReservationPassengersByPassengerIdUseCase
{
    private readonly IReservationPassengerRepository _repository;

    public GetReservationPassengersByPassengerIdUseCase(IReservationPassengerRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<ReservationPassenger>> ExecuteAsync(int passengerId)
    {
        return _repository.GetByPassengerIdAsync(ReservationPassengerPassengerId.Create(passengerId));
    }
}

