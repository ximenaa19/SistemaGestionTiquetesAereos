using GestionAerolineas.src.Modules.Sessions.Domain.Aggregate;
using GestionAerolineas.src.Modules.Sessions.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Sessions.Application.UseCases;

public class GetSessionsByDateRangeUseCase
{
    private readonly ISessionRepository _repository;

    public GetSessionsByDateRangeUseCase(ISessionRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Session>> ExecuteAsync(DateTime from, DateTime to)
    {
        if (to < from)
            throw new Exception("La fecha final no puede ser menor que la inicial");

        return await _repository.GetByDateRangeAsync(from, to);
    }
}
