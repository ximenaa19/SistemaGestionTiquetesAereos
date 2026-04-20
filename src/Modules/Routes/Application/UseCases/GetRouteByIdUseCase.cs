using GestionAerolineas.src.Modules.Routes.Domain.Aggregate;
using GestionAerolineas.src.Modules.Routes.Domain.Repositories;
using GestionAerolineas.src.Modules.Routes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Routes.Application.UseCases;

public class GetRouteByIdUseCase
{
    private readonly IRouteRepository _repository;

    public GetRouteByIdUseCase(IRouteRepository repository)
    {
        _repository = repository;
    }

    public Task<Route?> ExecuteAsync(int id)
    {
        return _repository.GetByIdAsync(RouteId.Create(id));
    }
}

