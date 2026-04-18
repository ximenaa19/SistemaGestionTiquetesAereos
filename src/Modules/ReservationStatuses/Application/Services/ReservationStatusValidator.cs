using GestionAerolineas.src.Modules.ReservationStatuses.Application.Interfaces;
using GestionAerolineas.src.Modules.ReservationStatuses.Domain.Repositories;
using GestionAerolineas.src.Modules.ReservationStatuses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.ReservationStatuses.Application.Services;

public class ReservationStatusValidator : IReservationStatusValidator
{
    private readonly IReservationStatusRepository _repository;

    public ReservationStatusValidator(IReservationStatusRepository repository)
    {
        _repository = repository;
    }

    public async Task ValidateNameAsync(ReservationStatusName name, ReservationStatusId? currentId = null)
    {
        var normalizedCandidate = ReservationStatusName.Normalize(name.Value);
        var all = await _repository.GetAllAsync();

        foreach (var item in all)
        {
            if (currentId != null && item.Id.Value == currentId.Value)
                continue;

            if (ReservationStatusName.Normalize(item.Name.Value) == normalizedCandidate)
                throw new Exception("Ya existe un estado de reserva con ese nombre");
        }
    }
}
