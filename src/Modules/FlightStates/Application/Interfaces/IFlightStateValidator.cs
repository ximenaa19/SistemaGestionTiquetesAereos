using GestionAerolineas.src.Modules.FlightStates.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightStates.Application.Interfaces;

public interface IFlightStateValidator
{
    Task ValidateNameAsync(FlightStateName name, FlightStateId? currentId = null);
}
