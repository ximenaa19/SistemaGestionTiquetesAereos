using GestionAerolineas.src.Modules.FlightSeats.Domain.Aggregate;
using GestionAerolineas.src.Modules.FlightSeats.Domain.Repositories;
using GestionAerolineas.src.Modules.FlightSeats.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightSeats.Application.UseCases;

public class GetOccupiedSeatsByFlightIdUseCase
{
    private readonly IFlightSeatRepository _repository;

    public GetOccupiedSeatsByFlightIdUseCase(IFlightSeatRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<FlightSeat>> ExecuteAsync(int flightId)
    {
        return _repository.GetByFlightIdAndOccupiedAsync(FlightSeatFlightId.Create(flightId), FlightSeatIsOccupied.Create(true));
    }
}

