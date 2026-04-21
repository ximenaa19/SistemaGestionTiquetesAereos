using GestionAerolineas.src.Modules.Sessions.Domain.Aggregate;
using GestionAerolineas.src.Modules.Sessions.Domain.Repositories;
using GestionAerolineas.src.Modules.Sessions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Sessions.Application.UseCases;

public class GetSessionsByUserIdUseCase
{
    private readonly ISessionRepository _repository;

    public GetSessionsByUserIdUseCase(ISessionRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Session>> ExecuteAsync(int userId)
    {
        return _repository.GetByUserIdAsync(SessionUserId.Create(userId));
    }
}
