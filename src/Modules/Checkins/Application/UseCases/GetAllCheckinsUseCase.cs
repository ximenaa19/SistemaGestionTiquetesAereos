using GestionAerolineas.src.Modules.Checkins.Domain.Aggregate;
using GestionAerolineas.src.Modules.Checkins.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Checkins.Application.UseCases;

public class GetAllCheckinsUseCase
{
    private readonly ICheckinRepository _repository;

    public GetAllCheckinsUseCase(ICheckinRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Checkin>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}

