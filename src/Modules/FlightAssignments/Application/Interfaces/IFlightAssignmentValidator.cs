using GestionAerolineas.src.Modules.FlightAssignments.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightAssignments.Application.Interfaces;

public interface IFlightAssignmentValidator
{
    Task ValidateFlightExistsAsync(FlightAssignmentFlightId flightId);
    Task ValidateStaffExistsAndActiveAsync(FlightAssignmentStaffId staffId);
    Task ValidateFlightRoleExistsAsync(FlightAssignmentFlightRoleId flightRoleId);
    Task ValidateUniqueFlightAndStaffAsync(FlightAssignmentFlightId flightId, FlightAssignmentStaffId staffId, FlightAssignmentId? currentId = null);
    Task ValidateNoStaffOverlapAsync(FlightAssignmentStaffId staffId, FlightAssignmentFlightId flightId, FlightAssignmentId? currentId = null);
    Task ValidateStaffAirlineConsistencyAsync(FlightAssignmentStaffId staffId, FlightAssignmentFlightId flightId);
    Task ValidateAirportStaffMatchesRouteAsync(FlightAssignmentStaffId staffId, FlightAssignmentFlightId flightId);
    Task ValidateFlightNotInFinalStateAsync(FlightAssignmentFlightId flightId);
}

