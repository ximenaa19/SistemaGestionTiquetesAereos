using GestionAerolineas.src.Modules.CabinConfiguration.Domain.Aggregate;
using GestionAerolineas.src.Modules.CabinConfiguration.Domain.Repositories;
using GestionAerolineas.src.Modules.CabinConfiguration.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CabinConfiguration.Application.UseCases;

public class GetCabinConfigurationByAircraftAndCabinTypeUseCase
{
    private readonly ICabinConfigurationRepository _repository;

    public GetCabinConfigurationByAircraftAndCabinTypeUseCase(ICabinConfigurationRepository repository)
    {
        _repository = repository;
    }

    public Task<CabinConfigurationAggregate?> ExecuteAsync(int aircraftId, int cabinTypeId)
    {
        return _repository.GetByAircraftAndCabinTypeAsync(
            CabinConfigurationAircraftId.Create(aircraftId),
            CabinConfigurationCabinTypeId.Create(cabinTypeId)
        );
    }
}
