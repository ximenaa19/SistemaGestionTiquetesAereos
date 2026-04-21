using GestionAerolineas.src.Modules.RouteStops.Domain.Aggregate;
using GestionAerolineas.src.Modules.RouteStops.Domain.Repositories;
using GestionAerolineas.src.Modules.RouteStops.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.RouteStops.Application.UseCases;

public class GetRouteStopsByRouteIdUseCase
{
    private readonly IRouteStopRepository _repository;

    public GetRouteStopsByRouteIdUseCase(IRouteStopRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<RouteStop>> ExecuteAsync(int routeId)
    {
        return _repository.GetByRouteIdAsync(RouteStopRouteId.Create(routeId));
    }
}

