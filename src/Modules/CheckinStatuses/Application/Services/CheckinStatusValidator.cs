using GestionAerolineas.src.Modules.CheckinStatuses.Application.Interfaces;
using GestionAerolineas.src.Modules.CheckinStatuses.Domain.Repositories;
using GestionAerolineas.src.Modules.CheckinStatuses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CheckinStatuses.Application.Services;

public class CheckinStatusValidator : ICheckinStatusValidator
{
    private readonly ICheckinStatusRepository _repository;

    public CheckinStatusValidator(ICheckinStatusRepository repository)
    {
        _repository = repository;
    }

    public async Task ValidateNameAsync(CheckinStatusName name, CheckinStatusId? currentId = null)
    {
        var existingByName = await _repository.GetByNameAsync(name);

        if (existingByName is not null && existingByName.Id != currentId)
            throw new Exception("Ya existe un estado de checkin con ese nombre");
    }
}
