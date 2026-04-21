using GestionAerolineas.src.Modules.CabinConfiguration.Domain.Aggregate;
using GestionAerolineas.src.Modules.CabinConfiguration.Domain.Repositories;

namespace GestionAerolineas.src.Modules.CabinConfiguration.Application.UseCases;

public class GetAllCabinConfigurationsUseCase
{
    private readonly ICabinConfigurationRepository _repository;

    public GetAllCabinConfigurationsUseCase(ICabinConfigurationRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<CabinConfigurationAggregate>> ExecuteAsync()
    {
        return _repository.GetAllAsync();
    }
}
