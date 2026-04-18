using GestionAerolineas.src.Modules.StaffRoles.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.StaffRoles.Application.Interfaces;

public interface IStaffRoleValidator
{
    Task ValidateNameAsync(StaffRoleName name, StaffRoleId? currentId = null);
}
