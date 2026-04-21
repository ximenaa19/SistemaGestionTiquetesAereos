using GestionAerolineas.src.Modules.StaffAvailability.Application.Interfaces;
using GestionAerolineas.src.Modules.StaffAvailability.Domain.Aggregate;
using GestionAerolineas.src.Modules.StaffAvailability.Domain.Repositories;
using GestionAerolineas.src.Modules.StaffAvailability.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.StaffAvailability.Application.UseCases;

public class UpdateStaffAvailabilityUseCase
{
    private readonly IStaffAvailabilityRepository _repository;
    private readonly IStaffAvailabilityValidator _validator;

    public UpdateStaffAvailabilityUseCase(IStaffAvailabilityRepository repository, IStaffAvailabilityValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(int id, int staffId, int statusId, DateTime startDateTime, DateTime endDateTime, string? observation)
    {
        var idVO = StaffAvailabilityId.Create(id);
        var staffIdVO = StaffAvailabilityStaffId.Create(staffId);
        var statusIdVO = StaffAvailabilityStatusId.Create(statusId);
        var startVO = StaffAvailabilityStartDateTime.Create(startDateTime);
        var endVO = StaffAvailabilityEndDateTime.Create(endDateTime);
        var observationVO = StaffAvailabilityObservation.Create(observation);

        await _validator.ValidateStaffExistsAndActiveAsync(staffIdVO);
        await _validator.ValidateStatusExistsAsync(statusIdVO);
        _validator.ValidateDateRange(startVO, endVO);
        await _validator.ValidateNoOverlapAsync(staffIdVO, startVO, endVO, idVO);

        var entity = StaffAvailabilityBlock.Create(idVO, staffIdVO, statusIdVO, startVO, endVO, observationVO);
        await _repository.UpdateAsync(entity);
    }
}
