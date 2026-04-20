using System;
using GestionAerolineas.src.Modules.ReservationStatusTransitions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.ReservationStatusTransitions.Application.Interfaces;

public interface IReservationStatusTransitionValidator
{
    Task ValidatePairAsync(
        ReservationStatusOriginId originStatusId,
        ReservationStatusDestinationId destinationStatusId,
        ReservationStatusTransitionId? currentId = null
    );

}
