using GestionAerolineas.src.Modules.ReservationPassengers.Domain.Aggregate;
using GestionAerolineas.src.Modules.ReservationPassengers.Domain.Repositories;

namespace GestionAerolineas.src.Modules.ReservationPassengers.Application.UseCases;

public class GetAllReservationPassengersUseCase
{
    private readonly IReservationPassengerRepository _repository;

    public GetAllReservationPassengersUseCase(IReservationPassengerRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<ReservationPassenger>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}

