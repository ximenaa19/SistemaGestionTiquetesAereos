using GestionAerolineas.src.Modules.FlightSeats.Domain.Aggregate;
using GestionAerolineas.src.Modules.FlightSeats.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.FlightSeats.Domain.Repositories;

public interface IFlightSeatRepository
{
    Task<IEnumerable<FlightSeat>> GetAllAsync();
    Task<FlightSeat?> GetByIdAsync(FlightSeatId id);
    Task<IEnumerable<FlightSeat>> GetByFlightIdAsync(FlightSeatFlightId flightId);
    Task<FlightSeat?> GetByFlightAndCodeAsync(FlightSeatFlightId flightId, FlightSeatCode code);
    Task<IEnumerable<FlightSeat>> GetByFlightIdAndOccupiedAsync(FlightSeatFlightId flightId, FlightSeatIsOccupied isOccupied);
    Task AddAsync(FlightSeat seat);
    Task UpdateAsync(FlightSeat seat);
    Task DeleteAsync(FlightSeat seat);
    Task<bool> ExistsAsync(FlightSeatId id);
    Task<bool> ExistsByFlightAndNormalizedCodeAsync(int flightId, string normalizedSeatCode, int? excludingId = null);
    Task<int> CountByFlightIdAsync(int flightId);
}

