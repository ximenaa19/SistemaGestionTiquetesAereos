using GestionAerolineas.src.Modules.FlightAssignments.Domain.Aggregate;
using GestionAerolineas.src.Modules.FlightAssignments.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightAssignments.Domain.Repositories;

public interface IFlightAssignmentRepository
{
    Task<IEnumerable<FlightAssignment>> GetAllAsync();
    Task<FlightAssignment?> GetByIdAsync(FlightAssignmentId id);
    Task<IEnumerable<FlightAssignment>> GetByFlightIdAsync(FlightAssignmentFlightId flightId);
    Task<IEnumerable<FlightAssignment>> GetByStaffIdAsync(FlightAssignmentStaffId staffId);
    Task<IEnumerable<FlightAssignment>> GetByFlightRoleIdAsync(FlightAssignmentFlightRoleId flightRoleId);
    Task<FlightAssignment?> GetByFlightAndStaffAsync(FlightAssignmentFlightId flightId, FlightAssignmentStaffId staffId);
    Task AddAsync(FlightAssignment assignment);
    Task UpdateAsync(FlightAssignment assignment);
    Task DeleteAsync(FlightAssignment assignment);
    Task<bool> ExistsAsync(FlightAssignmentId id);
    Task<bool> ExistsByFlightAndStaffAsync(int flightId, int staffId, int? excludingId = null);
    Task<bool> ExistsStaffOverlapAsync(int staffId, DateTime departure, DateTime arrival, int? excludingId = null);
}

