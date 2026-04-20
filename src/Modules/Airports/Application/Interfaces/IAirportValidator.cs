using GestionAerolineas.src.Modules.Airports.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Airports.Application.Interfaces;

public interface IAirportValidator
{
    Task ValidateCityExistsAsync(AirportCityId cityId);
    Task ValidateNameAsync(AirportName name, AirportCityId cityId, AirportId? currentId = null);
    Task ValidateIataCodeAsync(AirportIataCode iataCode, AirportId? currentId = null);
    Task ValidateIcaoCodeAsync(AirportIcaoCode? icaoCode, AirportId? currentId = null);
}
