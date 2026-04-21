using GestionAerolineas.src.Modules.FlightSeats.Domain.Aggregate;
using GestionAerolineas.src.Modules.FlightSeats.Domain.Repositories;

namespace GestionAerolineas.src.Modules.FlightSeats.Application.UseCases;

public class GetAllFlightSeatsUseCase
{
    private readonly IFlightSeatRepository _repository;

    public GetAllFlightSeatsUseCase(IFlightSeatRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<FlightSeat>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}

