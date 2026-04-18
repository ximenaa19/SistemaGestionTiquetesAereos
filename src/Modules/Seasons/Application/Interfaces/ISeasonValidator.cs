using GestionAerolineas.src.Modules.Seasons.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Seasons.Application.Interfaces;

public interface ISeasonValidator
{
    Task ValidateNameAsync(SeasonName name, SeasonId? currentId = null);
}
