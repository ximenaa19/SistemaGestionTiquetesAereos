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
        var existingByName = await _repository.GetByNameAsync(name);

        if (existingByName is not null && existingByName.Id != currentId)
            throw new Exception("Ya existe un estado de reserva con ese nombre");
    }
}
