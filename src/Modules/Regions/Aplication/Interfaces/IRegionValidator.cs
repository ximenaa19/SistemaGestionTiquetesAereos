using GestionAerolineas.src.Modules.Regions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Regions.Application.Interfaces;

public interface IRegionValidator
{
    Task ValidateCountryExistsAsync(RegionCountryId countryId);
    Task ValidateNameAsync(RegionName name, RegionCountryId countryId, RegionId? currentId = null);
}

