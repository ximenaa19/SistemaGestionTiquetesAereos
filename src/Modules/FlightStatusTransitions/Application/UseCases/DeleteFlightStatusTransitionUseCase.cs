using GestionAerolineas.src.Modules.FlightStatusTransitions.Domain.Repositories;
using GestionAerolineas.src.Modules.FlightStatusTransitions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightStatusTransitions.Application.UseCases;

public class DeleteFlightStatusTransitionUseCase
{
    private readonly IFlightStatusTransitionRepository _repository;

    public DeleteFlightStatusTransitionUseCase(IFlightStatusTransitionRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var idVO = FlightStatusTransitionId.Create(id);

        var existing = await _repository.GetByIdAsync(idVO);

        if (existing is null)
            throw new Exception("La transición no existe");

        await _repository.DeleteAsync(existing);
    }
}

