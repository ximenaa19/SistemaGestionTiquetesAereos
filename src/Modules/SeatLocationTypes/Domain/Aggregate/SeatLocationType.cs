using GestionAerolineas.src.Modules.SeatLocationTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.SeatLocationTypes.Domain.Aggregate;

public class SeatLocationType
{
    public SeatLocationTypeId Id { get; private set; }
    public SeatLocationTypeName Name { get; private set; }

    private SeatLocationType(SeatLocationTypeId id, SeatLocationTypeName name)
    {
        Id = id;
        Name = name;
    }

    public static SeatLocationType Create(SeatLocationTypeId id, SeatLocationTypeName name)
    {
        return new SeatLocationType(id, name);
    }

    public static SeatLocationType CreateNew(SeatLocationTypeName name)
    {
        return new SeatLocationType(SeatLocationTypeId.CreateEmpty(), name);
    }
}

