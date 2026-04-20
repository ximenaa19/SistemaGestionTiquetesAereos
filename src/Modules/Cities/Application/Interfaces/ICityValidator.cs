using GestionAerolineas.src.Modules.Cities.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Cities.Application.Interfaces;

public interface ICityValidator
{
    Task ValidateRegionExistsAsync(CityRegionId regionId);
    Task ValidateNameAsync(CityName name, CityRegionId regionId, CityId? currentId = null);
}
