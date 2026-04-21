using GestionAerolineas.src.Modules.Sessions.Domain.Aggregate;
using GestionAerolineas.src.Modules.Sessions.Domain.Repositories;
using GestionAerolineas.src.Modules.Sessions.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Sessions.Application.UseCases;

public class GetSessionByIdUseCase
{
    private readonly ISessionRepository _repository;

    public GetSessionByIdUseCase(ISessionRepository repository)
    {
        _repository = repository;
    }

    public Task<Session?> ExecuteAsync(int id)
    {
        return _repository.GetByIdAsync(SessionId.Create(id));
    }
}
