using GestionAerolineas.src.Modules.FlightAssignments.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightAssignments.Domain.Aggregate;

public class FlightAssignment
{
    public FlightAssignmentId Id { get; private set; }
    public FlightAssignmentFlightId FlightId { get; private set; }
    public FlightAssignmentStaffId StaffId { get; private set; }
    public FlightAssignmentFlightRoleId FlightRoleId { get; private set; }

    private FlightAssignment(
        FlightAssignmentId id,
        FlightAssignmentFlightId flightId,
        FlightAssignmentStaffId staffId,
        FlightAssignmentFlightRoleId flightRoleId)
    {
        Id = id;
        FlightId = flightId;
        StaffId = staffId;
        FlightRoleId = flightRoleId;
    }

    public static FlightAssignment Create(
        FlightAssignmentId id,
        FlightAssignmentFlightId flightId,
        FlightAssignmentStaffId staffId,
        FlightAssignmentFlightRoleId flightRoleId)
    {
        return new FlightAssignment(id, flightId, staffId, flightRoleId);
    }

    public static FlightAssignment CreateNew(
        FlightAssignmentFlightId flightId,
        FlightAssignmentStaffId staffId,
        FlightAssignmentFlightRoleId flightRoleId)
    {
        return new FlightAssignment(FlightAssignmentId.CreateEmpty(), flightId, staffId, flightRoleId);
    }
}

