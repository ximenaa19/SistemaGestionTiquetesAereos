using GestionAerolineas.src.Modules.RouteStops.Domain.Aggregate;
using GestionAerolineas.src.Modules.RouteStops.Domain.Repositories;
using GestionAerolineas.src.Modules.RouteStops.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.RouteStops.Application.UseCases;

public class GetRouteStopByIdUseCase
{
    private readonly IRouteStopRepository _repository;

    public GetRouteStopByIdUseCase(IRouteStopRepository repository)
    {
        _repository = repository;
    }

    public Task<RouteStop?> ExecuteAsync(int id)
    {
        return _repository.GetByIdAsync(RouteStopId.Create(id));
    }
}

