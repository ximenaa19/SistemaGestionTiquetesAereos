using GestionAerolineas.src.Modules.Sessions.Domain.Aggregate;
using GestionAerolineas.src.Modules.Sessions.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Sessions.Application.UseCases;

public class GetAllSessionsUseCase
{
    private readonly ISessionRepository _repository;

    public GetAllSessionsUseCase(ISessionRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Session>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}
