using GestionAerolineas.src.Modules.SystemRoles.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.SystemRoles.Domain.Aggregate;

public class SystemRole
{
    public SystemRoleId Id { get; private set; }
    public SystemRoleName Name { get; private set; }
    public SystemRoleDescription Description { get; private set; }

    private SystemRole(SystemRoleId id, SystemRoleName name, SystemRoleDescription description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public static SystemRole Create(SystemRoleId id, SystemRoleName name, SystemRoleDescription description)
    {
        return new SystemRole(id, name, description);
    }

    public static SystemRole CreateNew(SystemRoleName name, SystemRoleDescription description)
    {
        return new SystemRole(SystemRoleId.CreateEmpty(), name, description);
    }
}
