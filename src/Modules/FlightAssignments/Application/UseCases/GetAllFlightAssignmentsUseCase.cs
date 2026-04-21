using GestionAerolineas.src.Modules.FlightAssignments.Domain.Aggregate;
using GestionAerolineas.src.Modules.FlightAssignments.Domain.Repositories;

namespace GestionAerolineas.src.Modules.FlightAssignments.Application.UseCases;

public class GetAllFlightAssignmentsUseCase
{
    private readonly IFlightAssignmentRepository _repository;

    public GetAllFlightAssignmentsUseCase(IFlightAssignmentRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<FlightAssignment>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}

