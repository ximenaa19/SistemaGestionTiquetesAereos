using GestionAerolineas.src.Modules.FlightAssignments.Domain.Aggregate;
using GestionAerolineas.src.Modules.FlightAssignments.Domain.Repositories;
using GestionAerolineas.src.Modules.FlightAssignments.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightAssignments.Application.UseCases;

public class GetFlightAssignmentsByFlightRoleIdUseCase
{
    private readonly IFlightAssignmentRepository _repository;

    public GetFlightAssignmentsByFlightRoleIdUseCase(IFlightAssignmentRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<FlightAssignment>> ExecuteAsync(int flightRoleId)
    {
        return _repository.GetByFlightRoleIdAsync(FlightAssignmentFlightRoleId.Create(flightRoleId));
    }
}

