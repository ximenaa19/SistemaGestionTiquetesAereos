using GestionAerolineas.src.Modules.Aircraft.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Aircraft.Application.Interfaces;

public interface IAircraftValidator
{
    Task ValidateModelExistsAsync(AircraftModelId modelId);
    Task ValidateAirlineExistsAsync(AircraftAirlineId airlineId);
    Task ValidateRegistrationAsync(AircraftRegistration registration, AircraftId? currentId = null);
}

