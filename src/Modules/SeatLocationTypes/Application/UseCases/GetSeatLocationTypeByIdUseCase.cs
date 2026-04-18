using GestionAerolineas.src.Modules.SeatLocationTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.SeatLocationTypes.Domain.Repositories;
using GestionAerolineas.src.Modules.SeatLocationTypes.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.SeatLocationTypes.Application.UseCases;

public class GetSeatLocationTypeByIdUseCase
{
    private readonly ISeatLocationTypeRepository _repository;

    public GetSeatLocationTypeByIdUseCase(ISeatLocationTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<SeatLocationType?> ExecuteAsync(int id)
    {
        var idVO = SeatLocationTypeId.Create(id);
        return await _repository.GetByIdAsync(idVO);
    }
}

