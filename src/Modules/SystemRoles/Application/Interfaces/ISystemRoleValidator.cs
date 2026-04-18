using GestionAerolineas.src.Modules.SystemRoles.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.SystemRoles.Application.Interfaces;

public interface ISystemRoleValidator
{
    Task ValidateNameAsync(SystemRoleName name, SystemRoleId? currentId = null);
}
