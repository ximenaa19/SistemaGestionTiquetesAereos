using GestionAerolineas.src.Modules.ReservationStatuses.Domain.Aggregate;
using GestionAerolineas.src.Modules.ReservationStatuses.Domain.Repositories;
using GestionAerolineas.src.Modules.ReservationStatuses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.ReservationStatuses.Application.UseCases;

public class GetReservationStatusByNameUseCase
{
    private readonly IReservationStatusRepository _repository;

    public GetReservationStatusByNameUseCase(IReservationStatusRepository repository)
    {
        _repository = repository;
    }

    public async Task<ReservationStatus?> ExecuteAsync(string name)
    {
        var nameVO = ReservationStatusName.Create(name);
        return await _repository.GetByNameAsync(nameVO);
    }
}

