using GestionAerolineas.src.Modules.ReservationStatuses.Application.Interfaces;
using GestionAerolineas.src.Modules.ReservationStatuses.Domain.Aggregate;
using GestionAerolineas.src.Modules.ReservationStatuses.Domain.Repositories;
using GestionAerolineas.src.Modules.ReservationStatuses.Domain.ValueObject;

namespace GestionAerolineas.src.Modules.ReservationStatuses.Application.UseCases;

public class CreateReservationStatusUseCase
{
    private readonly IReservationStatusRepository _repository;
    private readonly IReservationStatusValidator _validator;

    public CreateReservationStatusUseCase(
        IReservationStatusRepository repository,
        IReservationStatusValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task ExecuteAsync(string name)
    {
        var nameVO = ReservationStatusName.Create(name);

        await _validator.ValidateNameAsync(nameVO);

        var entity = ReservationStatus.CreateNew(nameVO);

        await _repository.AddAsync(entity);
    }
}

