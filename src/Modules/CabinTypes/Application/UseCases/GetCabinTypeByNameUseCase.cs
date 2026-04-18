using System;
using GestionAerolineas.src.Modules.CabinTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.CabinTypes.Domain.Repository;
using GestionAerolineas.src.Modules.CabinTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CabinTypes.Application.UseCases;

public class GetCabinTypeByName
{
    private readonly ICabinTypeRepository _repository;

    public GetCabinTypeByName(ICabinTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<CabinType?> ExecuteAsync(string name)
    {
        return await _repository.GetByNameAsync(CabinTypesName.Create(name));
    }

}
