using GestionAerolineas.src.Modules.FlightAssignments.Domain.Aggregate;
using GestionAerolineas.src.Modules.FlightAssignments.Domain.Repositories;
using GestionAerolineas.src.Modules.FlightAssignments.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightAssignments.Application.UseCases;

public class GetFlightAssignmentsByFlightIdUseCase
{
    private readonly IFlightAssignmentRepository _repository;

    public GetFlightAssignmentsByFlightIdUseCase(IFlightAssignmentRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<FlightAssignment>> ExecuteAsync(int flightId)
    {
        return _repository.GetByFlightIdAsync(FlightAssignmentFlightId.Create(flightId));
    }
}

