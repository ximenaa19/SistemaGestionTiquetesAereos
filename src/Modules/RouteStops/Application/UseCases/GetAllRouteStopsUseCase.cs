using GestionAerolineas.src.Modules.RouteStops.Domain.Aggregate;
using GestionAerolineas.src.Modules.RouteStops.Domain.Repositories;

namespace GestionAerolineas.src.Modules.RouteStops.Application.UseCases;

public class GetAllRouteStopsUseCase
{
    private readonly IRouteStopRepository _repository;

    public GetAllRouteStopsUseCase(IRouteStopRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<RouteStop>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}

