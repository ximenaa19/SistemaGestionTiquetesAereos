using GestionAerolineas.src.Modules.CheckinStatuses.Domain.Repositories;
using GestionAerolineas.src.Modules.CheckinStatuses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CheckinStatuses.Application.UseCases;

public class DeleteCheckinStatusUseCase
{
    private readonly ICheckinStatusRepository _repository;

    public DeleteCheckinStatusUseCase(ICheckinStatusRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var checkinStatusId = CheckinStatusId.Create(id);
        var checkinStatus = await _repository.GetByIdAsync(checkinStatusId);

        if (checkinStatus is null)
            throw new KeyNotFoundException($"CheckinStatus con id '{checkinStatusId.Value}' no existe.");

        await _repository.DeleteAsync(checkinStatus);
    }
}
