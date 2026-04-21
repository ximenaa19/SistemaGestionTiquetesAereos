using GestionAerolineas.src.Modules.Reservations.Domain.Aggregate;
using GestionAerolineas.src.Modules.Reservations.Domain.Repositories;
using GestionAerolineas.src.Modules.Reservations.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Reservations.Application.UseCases;

public class GetReservationByIdUseCase
{
    private readonly IReservationRepository _repository;

    public GetReservationByIdUseCase(IReservationRepository repository)
    {
        _repository = repository;
    }

    public Task<Reservation?> ExecuteAsync(int id)
    {
        return _repository.GetByIdAsync(ReservationId.Create(id));
    }
}

