using GestionAerolineas.src.Modules.StaffAvailability.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.StaffAvailability.Domain.Aggregate;

public class StaffAvailabilityBlock
{
    public StaffAvailabilityId Id { get; private set; }
    public StaffAvailabilityStaffId StaffId { get; private set; }
    public StaffAvailabilityStatusId StatusId { get; private set; }
    public StaffAvailabilityStartDateTime StartDateTime { get; private set; }
    public StaffAvailabilityEndDateTime EndDateTime { get; private set; }
    public StaffAvailabilityObservation Observation { get; private set; }

    private StaffAvailabilityBlock(
        StaffAvailabilityId id,
        StaffAvailabilityStaffId staffId,
        StaffAvailabilityStatusId statusId,
        StaffAvailabilityStartDateTime startDateTime,
        StaffAvailabilityEndDateTime endDateTime,
        StaffAvailabilityObservation observation)
    {
        Id = id;
        StaffId = staffId;
        StatusId = statusId;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Observation = observation;
    }

    public static StaffAvailabilityBlock Create(
        StaffAvailabilityId id,
        StaffAvailabilityStaffId staffId,
        StaffAvailabilityStatusId statusId,
        StaffAvailabilityStartDateTime startDateTime,
        StaffAvailabilityEndDateTime endDateTime,
        StaffAvailabilityObservation observation)
    {
        return new StaffAvailabilityBlock(id, staffId, statusId, startDateTime, endDateTime, observation);
    }

    public static StaffAvailabilityBlock CreateNew(
        StaffAvailabilityStaffId staffId,
        StaffAvailabilityStatusId statusId,
        StaffAvailabilityStartDateTime startDateTime,
        StaffAvailabilityEndDateTime endDateTime,
        StaffAvailabilityObservation observation)
    {
        return new StaffAvailabilityBlock(StaffAvailabilityId.CreateEmpty(), staffId, statusId, startDateTime, endDateTime, observation);
    }
}
