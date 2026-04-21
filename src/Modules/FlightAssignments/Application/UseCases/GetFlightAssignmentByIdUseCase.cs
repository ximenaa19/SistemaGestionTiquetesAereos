using GestionAerolineas.src.Modules.FlightAssignments.Domain.Aggregate;
using GestionAerolineas.src.Modules.FlightAssignments.Domain.Repositories;
using GestionAerolineas.src.Modules.FlightAssignments.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightAssignments.Application.UseCases;

public class GetFlightAssignmentByIdUseCase
{
    private readonly IFlightAssignmentRepository _repository;

    public GetFlightAssignmentByIdUseCase(IFlightAssignmentRepository repository)
    {
        _repository = repository;
    }

    public Task<FlightAssignment?> ExecuteAsync(int id)
    {
        return _repository.GetByIdAsync(FlightAssignmentId.Create(id));
    }
}

