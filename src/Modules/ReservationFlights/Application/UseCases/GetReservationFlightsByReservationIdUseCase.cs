using GestionAerolineas.src.Modules.ReservationFlights.Domain.Aggregate;
using GestionAerolineas.src.Modules.ReservationFlights.Domain.Repositories;
using GestionAerolineas.src.Modules.ReservationFlights.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.ReservationFlights.Application.UseCases;

public class GetReservationFlightsByReservationIdUseCase
{
    private readonly IReservationFlightRepository _repository;

    public GetReservationFlightsByReservationIdUseCase(IReservationFlightRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<ReservationFlight>> ExecuteAsync(int reservationId)
    {
        return _repository.GetByReservationIdAsync(ReservationFlightReservationId.Create(reservationId));
    }
}

