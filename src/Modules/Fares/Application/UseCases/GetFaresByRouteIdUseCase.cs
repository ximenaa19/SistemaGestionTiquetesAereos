using GestionAerolineas.src.Modules.Fares.Domain.Aggregate;
using GestionAerolineas.src.Modules.Fares.Domain.Repositories;
using GestionAerolineas.src.Modules.Fares.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Fares.Application.UseCases;

public class GetFaresByRouteIdUseCase
{
    private readonly IFareRepository _repository;

    public GetFaresByRouteIdUseCase(IFareRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Fare>> ExecuteAsync(int routeId)
    {
        return _repository.GetByRouteIdAsync(FareRouteId.Create(routeId));
    }
}

