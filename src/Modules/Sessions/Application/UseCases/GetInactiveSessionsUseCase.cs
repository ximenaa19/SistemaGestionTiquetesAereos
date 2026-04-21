using GestionAerolineas.src.Modules.Sessions.Domain.Aggregate;
using GestionAerolineas.src.Modules.Sessions.Domain.Repositories;
using GestionAerolineas.src.Modules.Sessions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Sessions.Application.UseCases;

public class GetInactiveSessionsUseCase
{
    private readonly ISessionRepository _repository;

    public GetInactiveSessionsUseCase(ISessionRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Session>> ExecuteAsync()
    {
        return _repository.GetByIsActiveAsync(SessionIsActive.Create(false));
    }
}
