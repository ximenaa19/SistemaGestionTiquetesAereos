using GestionAerolineas.src.Modules.AvailabilityStatuses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.AvailabilityStatuses.Domain.Aggregate;

public class AvailabilityStatus
{
    public AvailabilityStatusId Id { get; private set; }
    public AvailabilityStatusName Name { get; private set; }

    private AvailabilityStatus(AvailabilityStatusId id, AvailabilityStatusName name)
    {
        Id = id;
        Name = name;
    }

    public static AvailabilityStatus Create(AvailabilityStatusId id, AvailabilityStatusName name)
    {
        return new AvailabilityStatus(id, name);
    }

    public static AvailabilityStatus CreateNew(AvailabilityStatusName name)
    {
        return new AvailabilityStatus(AvailabilityStatusId.CreateEmpty(), name);
    }
}
