using GestionAerolineas.src.Modules.Routes.Domain.Aggregate;
using GestionAerolineas.src.Modules.Routes.Domain.Repositories;

namespace GestionAerolineas.src.Modules.Routes.Application.UseCases;

public class GetAllRoutesUseCase
{
    private readonly IRouteRepository _repository;

    public GetAllRoutesUseCase(IRouteRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Route>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}

