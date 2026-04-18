using GestionAerolineas.src.Modules.ReservationStatuses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.ReservationStatuses.Application.Interfaces;

public interface IReservationStatusValidator
{
    Task ValidateNameAsync(ReservationStatusName name, ReservationStatusId? currentId = null);
}
