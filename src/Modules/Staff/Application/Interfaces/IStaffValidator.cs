using GestionAerolineas.src.Modules.Staff.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Staff.Application.Interfaces;

public interface IStaffValidator
{
    Task ValidatePersonExistsAsync(StaffPersonId personId);
    Task ValidateRoleExistsAsync(StaffRoleId roleId);
    Task ValidateOptionalAirlineExistsAsync(StaffAirlineId airlineId);
    Task ValidateOptionalAirportExistsAsync(StaffAirportId airportId);
    Task ValidateUniquePersonAsync(StaffPersonId personId, StaffId? currentId = null);
    void ValidateHasAirlineOrAirport(StaffAirlineId airlineId, StaffAirportId airportId);
}

