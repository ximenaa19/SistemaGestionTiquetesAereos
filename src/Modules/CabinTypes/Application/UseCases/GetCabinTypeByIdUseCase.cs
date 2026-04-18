using System;
using GestionAerolineas.src.Modules.CabinTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.CabinTypes.Domain.Repository;
using GestionAerolineas.src.Modules.CabinTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CabinTypes.Application.UseCases;

public class GetCabinTypeByIdUseCase
{
    private readonly ICabinTypeRepository _repository;

    public GetCabinTypeByIdUseCase(ICabinTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<CabinType?> ExecuteAsync(int id)
    {
        return await _repository.GetByIdAsync(CabinTypesId.Create(id));
    }

}
