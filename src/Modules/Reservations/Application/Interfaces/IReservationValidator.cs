using GestionAerolineas.src.Modules.Reservations.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Reservations.Application.Interfaces;

public interface IReservationValidator
{
    Task ValidateCustomerExistsAsync(ReservationCustomerId customerId);
    Task ValidateStatusExistsAsync(ReservationStatusId statusId);
    Task ValidateCodeUniqueAsync(ReservationCode code, ReservationId? currentId = null);
    void ValidateExpiresAt(ReservationReservedAt reservedAt, ReservationExpiresAt expiresAt);
    Task ValidateStatusTransitionAsync(ReservationStatusId currentStatusId, ReservationStatusId newStatusId);
}

