using GestionAerolineas.src.Modules.RoadTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.RoadTypes.Application.Interfaces;

public interface IRoadTypeValidator
{
    Task ValidateNameAsync(RoadTypeName name);
}