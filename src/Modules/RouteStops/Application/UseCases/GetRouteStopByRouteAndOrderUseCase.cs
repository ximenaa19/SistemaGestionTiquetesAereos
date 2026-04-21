using GestionAerolineas.src.Modules.RouteStops.Domain.Aggregate;
using GestionAerolineas.src.Modules.RouteStops.Domain.Repositories;
using GestionAerolineas.src.Modules.RouteStops.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.RouteStops.Application.UseCases;

public class GetRouteStopByRouteAndOrderUseCase
{
    private readonly IRouteStopRepository _repository;

    public GetRouteStopByRouteAndOrderUseCase(IRouteStopRepository repository)
    {
        _repository = repository;
    }

    public Task<RouteStop?> ExecuteAsync(int routeId, int order)
    {
        return _repository.GetByRouteAndOrderAsync(
            RouteStopRouteId.Create(routeId),
            RouteStopOrder.Create(order)
        );
    }
}

