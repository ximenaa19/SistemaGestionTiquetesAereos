using GestionAerolineas.src.Modules.Routes.Domain.Aggregate;
using GestionAerolineas.src.Modules.Routes.Domain.Repositories;
using GestionAerolineas.src.Modules.Routes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Routes.Application.UseCases;

public class GetRouteByOriginAndDestinationUseCase
{
    private readonly IRouteRepository _repository;

    public GetRouteByOriginAndDestinationUseCase(IRouteRepository repository)
    {
        _repository = repository;
    }

    public Task<Route?> ExecuteAsync(int originAirportId, int destinationAirportId)
    {
        return _repository.GetByOriginAndDestinationAsync(
            RouteAirportId.Create(originAirportId),
            RouteAirportId.Create(destinationAirportId)
        );
    }
}

