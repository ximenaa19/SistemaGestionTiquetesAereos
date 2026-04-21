using GestionAerolineas.src.Modules.StaffAvailability.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.StaffAvailability.Application.Interfaces;

public interface IStaffAvailabilityValidator
{
    Task ValidateStaffExistsAndActiveAsync(StaffAvailabilityStaffId staffId);
    Task ValidateStatusExistsAsync(StaffAvailabilityStatusId statusId);
    void ValidateDateRange(StaffAvailabilityStartDateTime start, StaffAvailabilityEndDateTime end);
    Task ValidateNoOverlapAsync(StaffAvailabilityStaffId staffId, StaffAvailabilityStartDateTime start, StaffAvailabilityEndDateTime end, StaffAvailabilityId? currentId = null);
}

