using GestionAerolineas.src.Modules.CheckinStatuses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CheckinStatuses.Domain.Aggregate;

public class CheckinStatus
{
    public CheckinStatusId Id { get; private set; }
    public CheckinStatusName Name { get; private set; }

    private CheckinStatus(CheckinStatusId id, CheckinStatusName name)
    {
        Id = id;
        Name = name;
    }

    public static CheckinStatus Create(CheckinStatusId id, CheckinStatusName name)
    {
        return new CheckinStatus(id, name);
    }

    public static CheckinStatus CreateNew(CheckinStatusName name)
    {
        return new CheckinStatus(CheckinStatusId.CreateEmpty(), name);
    }
}
