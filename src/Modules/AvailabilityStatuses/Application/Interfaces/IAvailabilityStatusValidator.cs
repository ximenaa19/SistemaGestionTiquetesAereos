using GestionAerolineas.src.Modules.AvailabilityStatuses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.AvailabilityStatuses.Application.Interfaces;

public interface IAvailabilityStatusValidator
{
    Task ValidateNameAsync(AvailabilityStatusName name, AvailabilityStatusId? currentId = null);
}
