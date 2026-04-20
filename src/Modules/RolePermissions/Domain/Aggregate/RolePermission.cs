using GestionAerolineas.src.Modules.RolePermissions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.RolePermissions.Domain.Aggregate;

public class RolePermission
{
    public RolePermissionId Id { get; private set; }
    public SystemRoleId RoleId { get; private set; }
    public PermissionId PermissionId { get; private set; }

    private RolePermission(RolePermissionId id, SystemRoleId roleId, PermissionId permissionId)
    {
        Id = id;
        RoleId = roleId;
        PermissionId = permissionId;
    }

    public static RolePermission Create(RolePermissionId id, SystemRoleId roleId, PermissionId permissionId)
    {
        return new RolePermission(id, roleId, permissionId);
    }

    public static RolePermission CreateNew(SystemRoleId roleId, PermissionId permissionId)
    {
        return new RolePermission(RolePermissionId.CreateEmpty(), roleId, permissionId);
    }
}

