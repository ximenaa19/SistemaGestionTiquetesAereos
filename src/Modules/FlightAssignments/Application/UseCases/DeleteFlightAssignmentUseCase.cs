using GestionAerolineas.src.Modules.FlightAssignments.Domain.Repositories;
using GestionAerolineas.src.Modules.FlightAssignments.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightAssignments.Application.UseCases;

public class DeleteFlightAssignmentUseCase
{
    private readonly IFlightAssignmentRepository _repository;

    public DeleteFlightAssignmentUseCase(IFlightAssignmentRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(FlightAssignmentId.Create(id));
        if (entity is null)
            return;

        await _repository.DeleteAsync(entity);
    }
}

