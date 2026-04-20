using GestionAerolineas.src.Modules.AirportAirline.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.AirportAirline.Application.Interfaces;

public interface IAirportAirlineValidator
{
    Task ValidateAirportExistsAsync(AirportAirlineAirportId airportId);
    Task ValidateAirlineExistsAsync(AirportAirlineAirlineId airlineId);
    Task ValidateUniquePairAsync(AirportAirlineAirportId airportId, AirportAirlineAirlineId airlineId, AirportAirlineId? currentId = null);
    Task ValidateDatesAsync(AirportAirlineStartDate startDate, AirportAirlineEndDate endDate);
}

