using GestionAerolineas.src.Modules.Fares.Domain.Aggregate;
using GestionAerolineas.src.Modules.Fares.Domain.Repositories;
using GestionAerolineas.src.Modules.Fares.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Fares.Application.UseCases;

public class GetFareByKeysUseCase
{
    private readonly IFareRepository _repository;

    public GetFareByKeysUseCase(IFareRepository repository)
    {
        _repository = repository;
    }

    public Task<Fare?> ExecuteAsync(int routeId, int cabinTypeId, int passengerTypeId, int seasonId)
    {
        return _repository.GetByKeysAsync(
            FareRouteId.Create(routeId),
            FareCabinTypeId.Create(cabinTypeId),
            FarePassengerTypeId.Create(passengerTypeId),
            FareSeasonId.Create(seasonId));
    }
}

