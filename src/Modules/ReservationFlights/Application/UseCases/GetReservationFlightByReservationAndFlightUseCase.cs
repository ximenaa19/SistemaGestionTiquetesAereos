using GestionAerolineas.src.Modules.ReservationFlights.Domain.Aggregate;
using GestionAerolineas.src.Modules.ReservationFlights.Domain.Repositories;
using GestionAerolineas.src.Modules.ReservationFlights.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.ReservationFlights.Application.UseCases;

public class GetReservationFlightByReservationAndFlightUseCase
{
    private readonly IReservationFlightRepository _repository;

    public GetReservationFlightByReservationAndFlightUseCase(IReservationFlightRepository repository)
    {
        _repository = repository;
    }

    public Task<ReservationFlight?> ExecuteAsync(int reservationId, int flightId)
    {
        return _repository.GetByReservationAndFlightAsync(
            ReservationFlightReservationId.Create(reservationId),
            ReservationFlightFlightId.Create(flightId));
    }
}

