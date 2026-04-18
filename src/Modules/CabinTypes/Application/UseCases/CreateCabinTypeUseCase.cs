using System;
using GestionAerolineas.src.Modules.CabinTypes.Application.Interfaces;
using GestionAerolineas.src.Modules.CabinTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.CabinTypes.Domain.Repository;
using GestionAerolineas.src.Modules.CabinTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CabinTypes.Application.UseCases;

public class CreateCabinTypeUseCase
{
    private readonly ICabinTypeValidator _validator;
    private readonly ICabinTypeRepository _repository;

    public CreateCabinTypeUseCase(ICabinTypeValidator validator, ICabinTypeRepository repository)
    {
        _validator = validator;
        _repository = repository;
    }
    public async Task ExecuteAsync(int id, string name)
    {
        var nameVO = CabinTypesName.Create(name);

        await _validator.ValidateNameAsync(nameVO);

        var cabinType = CabinType.Create(
            CabinTypesId.Create(id),
            nameVO
        );

        await _repository.AddAsync(cabinType);
    }

}
