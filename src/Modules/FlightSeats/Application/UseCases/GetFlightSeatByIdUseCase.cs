using GestionAerolineas.src.Modules.FlightSeats.Domain.Aggregate;
using GestionAerolineas.src.Modules.FlightSeats.Domain.Repositories;
using GestionAerolineas.src.Modules.FlightSeats.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightSeats.Application.UseCases;

public class GetFlightSeatByIdUseCase
{
    private readonly IFlightSeatRepository _repository;

    public GetFlightSeatByIdUseCase(IFlightSeatRepository repository)
    {
        _repository = repository;
    }

    public Task<FlightSeat?> ExecuteAsync(int id)
    {
        return _repository.GetByIdAsync(FlightSeatId.Create(id));
    }
}

