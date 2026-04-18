using GestionAerolineas.src.Modules.ReservationStatuses.Domain.Aggregate;
using GestionAerolineas.src.Modules.ReservationStatuses.Domain.Repositories;
using GestionAerolineas.src.Modules.ReservationStatuses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.ReservationStatuses.Application.UseCases;

public class GetReservationStatusByIdUseCase
{
    private readonly IReservationStatusRepository _repository;

    public GetReservationStatusByIdUseCase(IReservationStatusRepository repository)
    {
        _repository = repository;
    }

    public async Task<ReservationStatus?> ExecuteAsync(int id)
    {
        var idVO = ReservationStatusId.Create(id);
        return await _repository.GetByIdAsync(idVO);
    }
}

