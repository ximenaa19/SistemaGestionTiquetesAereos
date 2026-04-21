using GestionAerolineas.src.Modules.Reservations.Domain.Aggregate;
using GestionAerolineas.src.Modules.Reservations.Domain.Repositories;
using GestionAerolineas.src.Modules.Reservations.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.Reservations.Application.UseCases;

public class GetReservationByCodeUseCase
{
    private readonly IReservationRepository _repository;

    public GetReservationByCodeUseCase(IReservationRepository repository)
    {
        _repository = repository;
    }

    public Task<Reservation?> ExecuteAsync(string code)
    {
        return _repository.GetByCodeAsync(ReservationCode.Create(code));
    }
}

