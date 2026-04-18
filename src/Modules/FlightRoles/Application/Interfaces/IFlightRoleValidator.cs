using GestionAerolineas.src.Modules.FlightRoles.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightRoles.Application.Interfaces;

public interface IFlightRoleValidator
{
    Task ValidateNameAsync(FlightRoleName name);
}

