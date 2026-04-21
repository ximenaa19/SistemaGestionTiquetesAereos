using GestionAerolineas.src.Modules.Sessions.Domain.Repositories;
using GestionAerolineas.src.Modules.Sessions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Sessions.Application.UseCases;

public class DeleteSessionUseCase
{
    private readonly ISessionRepository _repository;

    public DeleteSessionUseCase(ISessionRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(SessionId.Create(id));
        if (entity is null)
            throw new Exception("La session no existe");

        await _repository.DeleteAsync(entity);
    }
}
