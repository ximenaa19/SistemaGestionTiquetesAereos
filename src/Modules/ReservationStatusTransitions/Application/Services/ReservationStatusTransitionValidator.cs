using GestionAerolineas.src.Modules.ReservationStatusTransitions.Application.Interfaces;
using GestionAerolineas.src.Modules.ReservationStatusTransitions.Domain.Repositories;
using GestionAerolineas.src.Modules.ReservationStatusTransitions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.ReservationStatusTransitions.Application.Services;

public class ReservationStatusTransitionValidator : IReservationStatusTransitionValidator
{
    private readonly IReservationStatusTransitionRepository _repository;

    public ReservationStatusTransitionValidator(IReservationStatusTransitionRepository repository)
    {
        _repository = repository;
    }

    public async Task ValidatePairAsync(
        ReservationStatusOriginId originStatusId,
        ReservationStatusDestinationId destinationStatusId,
        ReservationStatusTransitionId? currentId = null)
    {
        if (originStatusId.Value == destinationStatusId.Value)
            throw new Exception("El estado de origen y destino no pueden ser el mismo");

        var existing = await _repository.GetByPairAsync(originStatusId, destinationStatusId);

        if (existing is null)
            return;

        if (currentId != null && existing.Id.Value == currentId.Value)
            return;

        throw new Exception("Ya existe una transición con ese origen y destino");
    }
}
