using GestionAerolineas.src.Modules.ReservationFlights.Domain.Aggregate;
using GestionAerolineas.src.Modules.ReservationFlights.Domain.Repositories;

namespace GestionAerolineas.src.Modules.ReservationFlights.Application.UseCases;

public class GetAllReservationFlightsUseCase
{
    private readonly IReservationFlightRepository _repository;

    public GetAllReservationFlightsUseCase(IReservationFlightRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<ReservationFlight>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}

