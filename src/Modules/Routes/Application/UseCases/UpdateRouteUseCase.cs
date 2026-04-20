using GestionAerolineas.src.Modules.Routes.Application.Interfaces;
using GestionAerolineas.src.Modules.Routes.Domain.Aggregate;
using GestionAerolineas.src.Modules.Routes.Domain.Repositories;
using GestionAerolineas.src.Modules.Routes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Routes.Application.UseCases;

public class UpdateRouteUseCase
{
    private readonly IRouteRepository _repository;
    private readonly IRouteValidator _validator;

    public UpdateRouteUseCase(IRouteRepository repository, IRouteValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(int id, int originAirportId, int destinationAirportId, int? distanceKm, int? estimatedDurationMin)
    {
        var idVO = RouteId.Create(id);
        var originVO = RouteAirportId.Create(originAirportId);
        var destinationVO = RouteAirportId.Create(destinationAirportId);
        var distanceVO = RouteDistanceKm.Create(distanceKm);
        var durationVO = RouteEstimatedDurationMinutes.Create(estimatedDurationMin);

        await _validator.ValidateAirportExistsAsync(originVO);
        await _validator.ValidateAirportExistsAsync(destinationVO);
        await _validator.ValidateDifferentAirportsAsync(originVO, destinationVO);
        await _validator.ValidateUniquePairAsync(originVO, destinationVO, idVO);

        var entity = Route.Create(idVO, originVO, destinationVO, distanceVO, durationVO);
        await _repository.UpdateAsync(entity);
    }
}

