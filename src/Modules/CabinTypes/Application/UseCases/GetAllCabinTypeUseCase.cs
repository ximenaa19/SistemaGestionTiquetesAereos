using System;
using GestionAerolineas.src.Modules.CabinTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.CabinTypes.Domain.Repository;

namespace GestionAerolineas.src.Modules.CabinTypes.Application.UseCases;

public class GetAllCabinTypeUseCase
{
    private readonly ICabinTypeRepository _repository;

    public GetAllCabinTypeUseCase(ICabinTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CabinType>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }

}
