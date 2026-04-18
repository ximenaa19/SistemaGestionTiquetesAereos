using GestionAerolineas.src.Modules.ReservationStatuses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.ReservationStatuses.Domain.Aggregate;

public class ReservationStatus
{
    public ReservationStatusId Id { get; private set; }
    public ReservationStatusName Name { get; private set; }

    private ReservationStatus(ReservationStatusId id, ReservationStatusName name)
    {
        Id = id;
        Name = name;
    }

    public static ReservationStatus Create(ReservationStatusId id, ReservationStatusName name)
    {
        return new ReservationStatus(id, name);
    }

    public static ReservationStatus CreateNew(ReservationStatusName name)
    {
        return new ReservationStatus(ReservationStatusId.CreateEmpty(), name);
    }
}

