using GestionAerolineas.src.Modules.AircraftManufacturers.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.AircraftManufacturers.Application.Interfaces;

public interface IAircraftManufacturerValidator
{
    Task ValidateNameAsync(AircraftManufacturerName name, AircraftManufacturerId? currentId = null);
    Task ValidateCountryExistsAsync(AircraftManufacturerCountryId countryId);
}

