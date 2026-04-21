using GestionAerolineas.src.Modules.ReservationFlights.Domain.Aggregate;
using GestionAerolineas.src.Modules.ReservationFlights.Domain.Repositories;
using GestionAerolineas.src.Modules.ReservationFlights.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.ReservationFlights.Application.UseCases;

public class GetReservationFlightsByFlightIdUseCase
{
    private readonly IReservationFlightRepository _repository;

    public GetReservationFlightsByFlightIdUseCase(IReservationFlightRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<ReservationFlight>> ExecuteAsync(int flightId)
    {
        return _repository.GetByFlightIdAsync(ReservationFlightFlightId.Create(flightId));
    }
}

