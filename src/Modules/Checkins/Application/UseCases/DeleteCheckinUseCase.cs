using GestionAerolineas.src.Modules.Checkins.Domain.Repositories;
using GestionAerolineas.src.Modules.Checkins.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Checkins.Application.UseCases;

public class DeleteCheckinUseCase
{
    private readonly ICheckinRepository _repository;

    public DeleteCheckinUseCase(ICheckinRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var idVO = CheckinId.Create(id);
        var existing = await _repository.GetByIdAsync(idVO);
        if (existing is null)
            throw new Exception("El check-in no existe");

        await _repository.DeleteAsync(existing);
    }
}

