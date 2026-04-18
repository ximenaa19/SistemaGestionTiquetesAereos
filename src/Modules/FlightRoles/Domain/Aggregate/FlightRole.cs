using GestionAerolineas.src.Modules.FlightRoles.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightRoles.Domain.Aggregate;

public class FlightRole
{
    public FlightRoleId Id { get; private set; }
    public FlightRoleName Name { get; private set; }

    private FlightRole(FlightRoleId id, FlightRoleName name)
    {
        Id = id;
        Name = name;
    }

    public static FlightRole Create(FlightRoleId id, FlightRoleName name)
    {
        return new FlightRole(id, name);
    }

    public static FlightRole CreateNew(FlightRoleName name)
    {
        return new FlightRole(FlightRoleId.CreateEmpty(), name);
    }
}

