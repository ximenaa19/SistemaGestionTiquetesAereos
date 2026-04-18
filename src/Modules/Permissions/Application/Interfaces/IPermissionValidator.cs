using GestionAerolineas.src.Modules.Permissions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Permissions.Application.Interfaces;

public interface IPermissionValidator
{
    Task ValidateNameAsync(PermissionName name, PermissionId? currentId = null);
}
