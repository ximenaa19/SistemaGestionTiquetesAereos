using GestionAerolineas.src.Modules.ReservationStatuses.Domain.Aggregate;
using GestionAerolineas.src.Modules.ReservationStatuses.Domain.Repositories;

namespace GestionAerolineas.src.Modules.ReservationStatuses.Application.UseCases;

public class GetAllReservationStatusesUseCase
{
    private readonly IReservationStatusRepository _repository;

    public GetAllReservationStatusesUseCase(IReservationStatusRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ReservationStatus>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}

