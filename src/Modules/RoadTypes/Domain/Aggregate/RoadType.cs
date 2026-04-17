using System;
using GestionAerolineas.src.Modules.RoadTypes.Domain.ValueObject;


namespace GestionAerolineas.src.Modules.RoadTypes.Domain.Aggregate;

public class RoadType
{
    public RoadTypeId Id { get; private set; }
    public RoadTypeName Name { get; private set; }

    private RoadType(RoadTypeId id, RoadTypeName name)
    {
        Id = id;
        Name = name;
    }

    public static RoadType Create(RoadTypeId id, RoadTypeName name)
    {
        return new RoadType(id, name);
    }
   

}
