using GestionAerolineas.src.Modules.RouteStops.Application.Interfaces;
using GestionAerolineas.src.Modules.RouteStops.Domain.Aggregate;
using GestionAerolineas.src.Modules.RouteStops.Domain.Repositories;
using GestionAerolineas.src.Modules.RouteStops.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.RouteStops.Application.UseCases;

public class CreateRouteStopUseCase
{
    private readonly IRouteStopRepository _repository;
    private readonly IRouteStopValidator _validator;

    public CreateRouteStopUseCase(IRouteStopRepository repository, IRouteStopValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(int routeId, int stopAirportId, int order, int durationMinutes)
    {
        var routeIdVO = RouteStopRouteId.Create(routeId);
        var stopAirportIdVO = RouteStopStopAirportId.Create(stopAirportId);
        var orderVO = RouteStopOrder.Create(order);
        var durationVO = RouteStopDurationMinutes.Create(durationMinutes);

        await _validator.ValidateRouteExistsAsync(routeIdVO);
        await _validator.ValidateStopAirportExistsAsync(stopAirportIdVO);
        await _validator.ValidateUniqueOrderInRouteAsync(routeIdVO, orderVO);
        await _validator.ValidateNoDuplicateStopAirportInRouteAsync(routeIdVO, stopAirportIdVO);
        await _validator.ValidateStopAirportNotOriginOrDestinationAsync(routeIdVO, stopAirportIdVO);

        var entity = RouteStop.CreateNew(routeIdVO, stopAirportIdVO, orderVO, durationVO);
        await _repository.AddAsync(entity);
    }
}

