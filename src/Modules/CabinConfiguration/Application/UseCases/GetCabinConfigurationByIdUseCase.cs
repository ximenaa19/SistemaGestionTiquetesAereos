using GestionAerolineas.src.Modules.CabinConfiguration.Domain.Aggregate;
using GestionAerolineas.src.Modules.CabinConfiguration.Domain.Repositories;
using GestionAerolineas.src.Modules.CabinConfiguration.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CabinConfiguration.Application.UseCases;

public class GetCabinConfigurationByIdUseCase
{
    private readonly ICabinConfigurationRepository _repository;

    public GetCabinConfigurationByIdUseCase(ICabinConfigurationRepository repository)
    {
        _repository = repository;
    }

    public Task<CabinConfigurationAggregate?> ExecuteAsync(int id)
    {
        return _repository.GetByIdAsync(CabinConfigurationId.Create(id));
    }
}
