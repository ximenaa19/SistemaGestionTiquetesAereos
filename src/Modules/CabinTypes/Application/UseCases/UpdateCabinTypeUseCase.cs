using System;
using GestionAerolineas.src.Modules.CabinTypes.Application.Interfaces;
using GestionAerolineas.src.Modules.CabinTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.CabinTypes.Domain.Repository;
using GestionAerolineas.src.Modules.CabinTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.CabinTypes.Application.UseCases;

public class UpdateCabinTypeUseCase
{
    private readonly ICabinTypeRepository _repository;
    private readonly ICabinTypeValidator _validator;
    public UpdateCabinTypeUseCase(ICabinTypeRepository repository, ICabinTypeValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }
    public async Task ExecuteAsync(int id, string name)
    {
        var idVO = CabinTypesId.Create(id);

        var existing = await _repository.GetByIdAsync(idVO);

        if (existing == null)
            throw new Exception("El CabinType no existe");

        var nameVO = CabinTypesName.Create(name);

        await _validator.ValidateNameAsync(nameVO);

        var updated = CabinType.Create(idVO, nameVO);

        await _repository.UpdateAsync(updated);
    }

}
