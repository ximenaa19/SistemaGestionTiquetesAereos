using GestionAerolineas.src.Modules.CabinConfiguration.Domain.Aggregate;
using GestionAerolineas.src.Modules.CabinConfiguration.Domain.Repositories;
using GestionAerolineas.src.Modules.CabinConfiguration.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CabinConfiguration.Application.UseCases;

public class GetCabinConfigurationsByAircraftIdUseCase
{
    private readonly ICabinConfigurationRepository _repository;

    public GetCabinConfigurationsByAircraftIdUseCase(ICabinConfigurationRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<CabinConfigurationAggregate>> ExecuteAsync(int aircraftId)
    {
        return _repository.GetByAircraftIdAsync(CabinConfigurationAircraftId.Create(aircraftId));
    }
}
