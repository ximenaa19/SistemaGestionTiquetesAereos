using GestionAerolineas.src.Modules.ReservationPassengers.Domain.Aggregate;
using GestionAerolineas.src.Modules.ReservationPassengers.Domain.Repositories;
using GestionAerolineas.src.Modules.ReservationPassengers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.ReservationPassengers.Application.UseCases;

public class GetReservationPassengerByIdUseCase
{
    private readonly IReservationPassengerRepository _repository;

    public GetReservationPassengerByIdUseCase(IReservationPassengerRepository repository)
    {
        _repository = repository;
    }

    public Task<ReservationPassenger?> ExecuteAsync(int id)
    {
        return _repository.GetByIdAsync(ReservationPassengerId.Create(id));
    }
}

