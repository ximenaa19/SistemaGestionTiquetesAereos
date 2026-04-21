using GestionAerolineas.src.Modules.ReservationFlights.Domain.Aggregate;
using GestionAerolineas.src.Modules.ReservationFlights.Domain.Repositories;
using GestionAerolineas.src.Modules.ReservationFlights.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.ReservationFlights.Application.UseCases;

public class GetReservationFlightByIdUseCase
{
    private readonly IReservationFlightRepository _repository;

    public GetReservationFlightByIdUseCase(IReservationFlightRepository repository)
    {
        _repository = repository;
    }

    public Task<ReservationFlight?> ExecuteAsync(int id)
    {
        return _repository.GetByIdAsync(ReservationFlightId.Create(id));
    }
}

