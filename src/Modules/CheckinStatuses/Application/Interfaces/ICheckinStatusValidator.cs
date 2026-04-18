using GestionAerolineas.src.Modules.CheckinStatuses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CheckinStatuses.Application.Interfaces;

public interface ICheckinStatusValidator
{
    Task ValidateNameAsync(CheckinStatusName name, CheckinStatusId? currentId = null);
}
