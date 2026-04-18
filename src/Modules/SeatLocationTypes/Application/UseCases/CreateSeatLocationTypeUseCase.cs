using GestionAerolineas.src.Modules.SeatLocationTypes.Application.Interfaces;
using GestionAerolineas.src.Modules.SeatLocationTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.SeatLocationTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.SeatLocationTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.SeatLocationTypes.Application.UseCases;

public class CreateSeatLocationTypeUseCase
{
    private const int MaxSeatLocationTypes = 3;

    private readonly ISeatLocationTypeRepository _repository;
    private readonly ISeatLocationTypeValidator _validator;

    public CreateSeatLocationTypeUseCase(
        ISeatLocationTypeRepository repository,
        ISeatLocationTypeValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(string name)
    {
        var currentCount = await _repository.CountAsync();
        if (currentCount >= MaxSeatLocationTypes)
            throw new Exception($"No se pueden crear más de {MaxSeatLocationTypes} tipos de ubicación de asiento");

        var nameVO = SeatLocationTypeName.Create(name);

        await _validator.ValidateNameAsync(nameVO);

        var entity = SeatLocationType.CreateNew(nameVO);

        await _repository.AddAsync(entity);
    }
}

