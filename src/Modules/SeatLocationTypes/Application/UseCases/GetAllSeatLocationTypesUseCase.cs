using GestionAerolineas.src.Modules.SeatLocationTypes.Domain.Aggregate;
using GestionAerolineas.src.Modules.SeatLocationTypes.Domain.Repositories;

namespace GestionAerolineas.src.Modules.SeatLocationTypes.Application.UseCases;

public class GetAllSeatLocationTypesUseCase
{
    private readonly ISeatLocationTypeRepository _repository;

    public GetAllSeatLocationTypesUseCase(ISeatLocationTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<SeatLocationType>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}

