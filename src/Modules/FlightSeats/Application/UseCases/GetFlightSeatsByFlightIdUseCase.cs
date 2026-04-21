using GestionAerolineas.src.Modules.FlightSeats.Domain.Aggregate;
using GestionAerolineas.src.Modules.FlightSeats.Domain.Repositories;
using GestionAerolineas.src.Modules.FlightSeats.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightSeats.Application.UseCases;

public class GetFlightSeatsByFlightIdUseCase
{
    private readonly IFlightSeatRepository _repository;

    public GetFlightSeatsByFlightIdUseCase(IFlightSeatRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<FlightSeat>> ExecuteAsync(int flightId)
    {
        return _repository.GetByFlightIdAsync(FlightSeatFlightId.Create(flightId));
    }
}

