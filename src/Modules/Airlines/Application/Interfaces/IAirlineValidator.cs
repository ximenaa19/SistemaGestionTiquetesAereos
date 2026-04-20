using GestionAerolineas.src.Modules.Airlines.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Airlines.Application.Interfaces;

public interface IAirlineValidator
{
    Task ValidateOriginCountryExistsAsync(AirlineOriginCountryId originCountryId);
    Task ValidateNameAsync(AirlineName name, AirlineOriginCountryId originCountryId, AirlineId? currentId = null);
    Task ValidateIataCodeAsync(AirlineIataCode iataCode, AirlineId? currentId = null);
}

