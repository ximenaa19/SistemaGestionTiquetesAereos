using GestionAerolineas.src.Modules.SeatLocationTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.SeatLocationTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.SeatLocationTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.SeatLocationTypes.Application.UseCases;

public class GetSeatLocationTypeByNameUseCase
{
    private readonly ISeatLocationTypeRepository _repository;

    public GetSeatLocationTypeByNameUseCase(ISeatLocationTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<SeatLocationType?> ExecuteAsync(string name)
    {
        var nameVO = SeatLocationTypeName.Create(name);
        return await _repository.GetByNameAsync(nameVO);
    }
}

